using Domain.Core.Interface.Request;
using Domain.Core.Interface.Rule;
using Inventory.Application.DTOs.Requests.FoodRecipe;
using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Domain.Common.Factories.Rule;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Commands.UpdateFoodRecipe
{
    public sealed record UpdateFoodRecipeCommand(Guid IdFoodRecipe, FoodRecipeRequest Request) : IRequest<FoodRecipeResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return QuantityRuleFactory.QuantityNotNegative(Request.Quantity);
        }
    }
}