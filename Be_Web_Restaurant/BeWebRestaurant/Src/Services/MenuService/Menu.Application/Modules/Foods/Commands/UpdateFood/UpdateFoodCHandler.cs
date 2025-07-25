﻿using Domain.Core.Rule.RuleFactory;
using Domain.Core.RuleException.Errors;
using MediatR;
using Menu.Application.DTOs.Responses.Food;
using Menu.Application.Interfaces;
using Menu.Application.Mapping.FoodMapExtension;
using Menu.Domain.Common.Message.ErrorMessages;
using Menu.Domain.Common.Message.FieldNames;

namespace Menu.Application.Modules.Foods.Commands.UpdateFood
{
    public sealed class UpdateFoodCHandler : IRequestHandler<UpdateFoodCommand, FoodResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateFoodCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FoodResponse> Handle(UpdateFoodCommand cm, CancellationToken token)
        {
            var repo = _uow.FoodRepo;
            var food = await repo.GetByIdAsync(cm.IdFood);
            if (food is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodField.IdFood, new[] { FoodMessages.IdFoodNotFound });
            }
            var foodtype = await _uow.FoodTypeRepo.GetByIdAsync(cm.Request.FoodTypeId);
            if (food.FoodTypeId != cm.Request.FoodTypeId && foodtype is null)
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.NotFound, FoodTypeField.IdFoodType, new[] { FoodTypeMessages.IdFoodTypeNotFound });
            }
            var newname = cm.Request.ToFoodName();
            if (food.FoodName != newname && await _uow.FoodRepo.ExistsByNameAsync(newname))
            {
                throw RuleFactory.SimpleRuleException(ErrorCode.Conflict, FoodField.FoodName, new[] { FoodMessages.FoodNameexisted });
            }

            food.ApplyBasicInfo(cm.Request);
            food.ApplyStatus(cm.Request);
            food.ApplyPrice(cm.Request);
            food.ApplyFoodTypeId(cm.Request);

            await _uow.FoodRepo.UpdateAsync(food);
            await _uow.SaveChangesAsync(token);
            return food.ToFoodResponse();
        }
    }
}