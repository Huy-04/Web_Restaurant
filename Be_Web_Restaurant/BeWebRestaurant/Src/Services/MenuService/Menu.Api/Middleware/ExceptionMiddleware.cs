using Domain.Core.Enums;
using Domain.Core.RuleException;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Menu.Api.Middleware
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
                    string.IsNullOrEmpty(ruleEx.Field) ? "General" : ruleEx.Field,
                    ruleEx.Messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await WriteProblemDetailsAsync(
                    context,
                    errorCode: ErrorCode.InternalServerError,
                    field: "ServerError",
                    messages: new[] { "Đã xảy ra lỗi không xác định. Vui lòng thử lại sau." });
            }
        }

        private static async Task WriteProblemDetailsAsync(
            HttpContext context,
            ErrorCode errorCode,
            string field,
            IEnumerable<string> messages)
        {
            int status = StatusCodes.Status500InternalServerError;
            StatusMap.TryGetValue(errorCode, out status);

            var problem = new ValidationProblemDetails(
                new Dictionary<string, string[]> { [field ?? "General"] = messages.ToArray() })
            {
                Status = status,
                Title = errorCode.ToString(),
                Instance = context.Request.Path
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(problem, options));
        }
    }
}