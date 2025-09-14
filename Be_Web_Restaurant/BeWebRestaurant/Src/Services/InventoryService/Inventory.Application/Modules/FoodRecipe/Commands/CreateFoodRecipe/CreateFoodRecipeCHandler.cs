using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.FoodRecipeMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Commands.CreateFoodRecipe
{
    public sealed class CreateFoodRecipeCHandler : IRequestHandler<CreateFoodRecipeCommand, FoodRecipeResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateFoodRecipeCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodRecipeResponse> Handle(CreateFoodRecipeCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var foodRecipe = command.Request.ToFoodRecipe();
                var ingredients = await _uow.IngredientsRepo.GetByIdAsync(foodRecipe.IngredientsId);
                if (ingredients is null)
                {
                    throw RuleFactory.SimpleRuleException
                        (ErrorCategory.NotFound,
                        IngredientsField.IdIngredients,
                        ErrorCode.IdNotFound,
                        new Dictionary<string, object>
                        {
                            {ParamField.Value,foodRecipe.IngredientsId }
                        });
                }
                await _uow.FoodRecipesRepo.CreateAsync(foodRecipe);
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