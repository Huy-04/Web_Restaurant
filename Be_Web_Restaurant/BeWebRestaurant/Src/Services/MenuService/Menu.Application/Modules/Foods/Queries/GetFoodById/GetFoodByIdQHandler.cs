using Domain.Core.Rule.RuleFactory;
using Domain.Core.RuleException.Errors;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Message.ErrorMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Application.Modules.Foods.Queries.GetFoodById
{
    public sealed class GetFoodByIdQHandler : IRequestHandler<GetFoodByIdQuery, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetFoodByIdQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(GetFoodByIdQuery query, CancellationToken token)
        {
            var entity = await _uow.FoodRepo.GetByIdAsync(query.IdFood);
            if (entity is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodField.IdFood, new[] { FoodMessages.IdFoodNotFound });
            }
            return entity.ToFoodResponse();
        }
    }
}