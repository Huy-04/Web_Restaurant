using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetAll
{
    public sealed class GetAllQHandler : IRequestHandler<GetallQuery, IEnumerable<StockReceiptResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<StockReceiptResponse>> Handle(GetallQuery query, CancellationToken token)
        {
            var stockReceipList = await _uow.StockReceiptRepo.GetAllAsync();
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();
            var unitList = await _uow.UnitRepo.GetAllAsync();

            var list = from s in stockReceipList
                       join i in ingredientsList on s.IngredientsId equals i.Id
                       join u in unitList on s.UnitId equals u.Id
                       select s.ToStockReceiptResponse(i.IngredientsName, u.UnitName);

            return list;
        }
    }
}