using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Ingredients;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.IngredientsMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Commands.UpdateIngredients
{
    public sealed class UpdateIngredientsCHandler : IRequestHandler<UpdateIngredientsCommand, IngredientsResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateIngredientsCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IngredientsResponse> Handle(UpdateIngredientsCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var repo = _uow.IngredientsRepo;

                var ingredients = await repo.GetByIdAsync(command.IdIngredients);
                if (ingredients is null)
                {
                    throw RuleFactory.SimpleRuleException
                         (ErrorCategory.NotFound,
                         IngredientsField.IdIngredients,
                         ErrorCode.IdNotFound,
                         new Dictionary<string, object>
                         {
                            {ParamField.Value,command.IdIngredients }
                         });
                }
                var entity = command.Request.ToIngredients();
                var unit = await _uow.UnitRepo.GetByIdAsync(entity.UnitId);
                if (unit is null)
                {
                    throw RuleFactory.SimpleRuleException
                         (ErrorCategory.NotFound,
                         UnitField.IdUnit,
                         ErrorCode.IdNotFound,
                         new Dictionary<string, object>
                         {
                            {ParamField.Value,entity.UnitId }
                         });
                }

                ingredients.Update(entity.IngredientsName, entity.Description, entity.UnitId);
                await _uow.CommitAsync(token);
                return ingredients.ToIngredientsResponse(unit.UnitName);
            }
            catch
            {
                await _uow.RollBackAsync(token);
                throw;
            }
        }
    }
}