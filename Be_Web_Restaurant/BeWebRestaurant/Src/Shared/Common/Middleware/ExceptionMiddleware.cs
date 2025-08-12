using Domain.Core.Enums;
using Domain.Core.RuleException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Common.Middleware
{
    public sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private static readonly Dictionary<ErrorCode, int> StatusMap = new()
        {
            [ErrorCode.ValidationFailed] = StatusCodes.Status400BadRequest,
            [ErrorCode.NotFound] = StatusCodes.Status404NotFound,
            [ErrorCode.Conflict] = StatusCodes.Status409Conflict,
            [ErrorCode.Unauthorized] = StatusCodes.Status401Unauthorized,
            [ErrorCode.Forbidden] = StatusCodes.Status403Forbidden,
            [ErrorCode.InternalServerError] = StatusCodes.Status500InternalServerError
        };

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessRuleException ruleEx)
            {
                _logger.LogWarning(ruleEx, "Business rule violation ({ErrorCode})", ruleEx.ErrorCode);

                await WriteProblemDetailsAsync(
                    context,
                    ruleEx.ErrorCode,
                    ruleEx.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await WriteProblemDetailsAsync(
                    context,
                    ErrorCode.InternalServerError,
                    new Dictionary<string, List<string>>
                    {
                        { "ServerError", new List<string> { "Đã xảy ra lỗi không xác định. Vui lòng thử lại sau." } }
                    });
            }
        }

        private static async Task WriteProblemDetailsAsync(
            HttpContext context,
            ErrorCode errorCode,
            IReadOnlyDictionary<string, List<string>> errors)
        {
            StatusMap.TryGetValue(errorCode, out var status);

            var modelState = new ModelStateDictionary();
            foreach (var (key, msgs) in errors)
            {
                foreach (var msg in msgs)
                    modelState.AddModelError(key, msg);         // mỗi lỗi AddModelError 1 lần
            }

            var problem = new ValidationProblemDetails(modelState)
            {
                Status = status,
                Title = errorCode.ToString(),
                Instance = context.Request.Path
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";

            var opts = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(problem, opts));
        }
    }
}