using Domain.Core.Rule;
using Domain.Core.Rule.EnumRule;
using Domain.Core.Rule.NumberRule;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Common.Factories.Rule
{
    public static class MeasurementRuleFactory
    {
        public static IBusinessRule ValueNotNegative(decimal value)
        {
            return new NotNegativeRule<decimal>(value, MeasurementField.Value);
        }

        public static IBusinessRule UnitValidate(UnitEnum unit)
        {
            var validate = Enum.GetValues(typeof(UnitEnum)).Cast<UnitEnum>().ToList();
            return new EnumValidateRule<UnitEnum>(unit, validate, MeasurementField.Unit);
        }
    }
}