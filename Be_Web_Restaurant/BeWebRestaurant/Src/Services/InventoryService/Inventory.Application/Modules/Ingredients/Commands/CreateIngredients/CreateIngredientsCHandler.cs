using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Application.DTOs.Responses.Ingredients;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.IngredientsMapExtension;
using Inventory.Domain.Common.Messages.FieldNames;
using MediatR;

namespace Inventory.Application.Modules.Ingredients.Commands.CreateIngredients
{
    public sealed class CreateIngredientsCHandler : IRequestHandler<CreateIngredientsCommand, IngredientsResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateIngredientsCHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IngredientsResponse> Handle(CreateIngredientsCommand command, CancellationToken token)
        {
            await _uow.BeginTransactionAsync(token);

            try
            {
                var ingredients = command.Request.ToIngredients();
                var unit = await _uow.UnitRepo.GetByIdAsync(ingredients.UnitId);
                if (unit is null)
                {
                    throw RuleFactory.SimpleRuleException
                         (ErrorCategory.NotFound,
                         UnitField.IdUnit,
                         ErrorCode.IdNotFound,
                         new Dictionary<string, object>
                         {
                            {ParamField.Value,ingredients.UnitId }
                         });
                }
                await _uow.IngredientsRepo.CreateAsync(ingredients);
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