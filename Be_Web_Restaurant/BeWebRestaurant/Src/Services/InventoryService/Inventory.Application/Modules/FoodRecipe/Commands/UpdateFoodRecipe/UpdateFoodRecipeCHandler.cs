using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.FoodRecipeMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Commands.UpdateFoodRecipe
{
    public sealed class UpdateFoodRecipeCHandler : IRequestHandler<UpdateFoodRecipeCommand, FoodRecipeResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateFoodRecipeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodRecipeResponse> Handle(UpdateFoodRecipeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.FoodRecipesRepo;

                var foodRecipe = await repo.GetByIdAsync(command.IdFoodRecipe);
                if (foodRecipe is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        FoodRecipeField.IdFoodRecipe,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,command.IdFoodRecipe }
                        });
                }
                var entity = command.Request.ToFoodRecipe();
                var ingredients = await _uow.IngredientsRepo.GetByIdAsync(entity.IngredientsId);
                if (ingredients is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        IngredientsField.IdIngredients,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,entity.IngredientsId }
                        });
                }
                foodRecipe.Update(entity.FoodId, entity.IngredientsId, entity.Quantity);
                await repo.UpdateAsync(foodRecipe);
                await _uow.CommitAsync(token);
                return foodRecipe.ToFoodRecipeResponse(ingredients.IngredientsName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}