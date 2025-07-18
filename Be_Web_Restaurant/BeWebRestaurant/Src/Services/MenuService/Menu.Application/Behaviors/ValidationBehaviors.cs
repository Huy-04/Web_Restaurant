using Domain.Core.Rule;
using MediatR;

namespace Menu.Application.Behaviors
{
    public sealed class ValidationBehaviors<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IValidateRequest
    {
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next, CancellationToken token)
        {
            RuleValidator.CheckRules(request.GetRule());

            return await next();
        }
    }
}