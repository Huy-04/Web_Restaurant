using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.StockReceipt;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.StockReceiptMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.StockReceipt.Queries.GetByIngredients
{
    public sealed class GetByIngredientsQHandler : IRequestHandler<GetByIngredientsQuery, IEnumerable<StockReceiptResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetByIngredientsQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<StockReceiptResponse>> Handle(GetByIngredientsQuery query, CancellationToken token)
        {
            var stockReceiptList = await _uow.StockReceiptRepo.GetByIngredientsAsync(query.IngredientsId);
            if (!stockReceiptList.Any())
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.NotFound,
                    IngredientsField.IdIngredients,
                    ErrorCode.IdNotFound,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,query.IngredientsId }
                    });
            }
            var ingredientsList = await _uow.IngredientsRepo.GetAllAsync();
            var unitList = await _uow.UnitRepo.GetAllAsync();

            var list = from s in stockReceiptList
                       join i in ingredientsList on s.IngredientsId equals i.Id
                       join u in unitList on s.UnitId equals u.Id
                       select s.ToStockReceiptResponse(i.IngredientsName, u.UnitName);

            return list;
        }
    }
}