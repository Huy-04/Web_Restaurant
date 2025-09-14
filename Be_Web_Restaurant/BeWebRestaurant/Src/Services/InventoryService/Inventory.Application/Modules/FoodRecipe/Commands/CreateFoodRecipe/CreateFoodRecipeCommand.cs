using Domain.Core.Rule;
using Inventory.Application.DTOs.Requests.FoodRecipe;
using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Domain.Common.Factories.Rule;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Commands.CreateFoodRecipe
{
    public sealed record CreateFoodRecipeCommand(FoodRecipeRequest Request) : IRequest<FoodRecipeResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return QuantityRuleFactory.QuantityNotNegative(Request.Quantity);
        }
    }
}