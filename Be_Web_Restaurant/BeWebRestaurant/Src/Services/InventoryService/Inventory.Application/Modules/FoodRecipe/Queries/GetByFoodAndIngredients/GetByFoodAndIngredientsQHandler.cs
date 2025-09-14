using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.FoodRecipeMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetByFoodAndIngredients
{
    public sealed class GetByFoodAndIngredientsQHandler : IRequestHandler<GetByFoodAndIngredientsQuery, IEnumerable<FoodRecipeResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetByFoodAndIngredientsQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodRecipeResponse>> Handle(GetByFoodAndIngredientsQuery query, CancellationToken token)
        {
            var foodRecipeList = await _uow.FoodRecipesRepo.GetByFoodAndIngredients(query.IngredientsId, query.FoodId);
            if (!foodRecipeList.Any())
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    FoodRecipeField.IdFoodAndIdIngredients,
                    ErrorCode.NoMatchingCombination,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,$"{query.FoodId}-{query.IngredientsId}" },
                    });
            }
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();
            var list = from f in foodRecipeList
                       join i in ingredientsList
                       on f.IngredientsId equals i.Id
                       select f.ToFoodRecipeResponse(i.IngredientsName);
            return list;
        }
    }
}