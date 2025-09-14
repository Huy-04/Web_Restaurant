using Inventory.Application.DTOs.Responses.FoodRecipe;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.FoodRecipeMapExtension;
using Inventory.Application.Modules.StockReceipt.Queries.GetAllStockReceipt;
using MediatR;

namespace Inventory.Application.Modules.FoodRecipe.Queries.GetAll
{
    public sealed class GetAllQHandler : IRequestHandler<GetAllQuery, IEnumerable<FoodRecipeResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<FoodRecipeResponse>> Handle(GetAllQuery query, CancellationToken token)
        {
            var foodRecipeList = await _uow.FoodRecipesRepo.GetAllAsync();
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();

            var list = from f in foodRecipeList
                       join i in ingredientsList
                       on f.IngredientsId equals i.Id
                       select f.ToFoodRecipeResponse(i.IngredientsName);

            return list;
        }
    }
}