using Domain.Core.Enums;
using Domain.Core.Messages.FieldNames;
using Domain.Core.Rule.RuleFactory;
using Inventory.Domain.Common.Messages.FieldNames;
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects.Common;

namespace Inventory.Domain.Extension
{
    public static class MeasurementEx
    {
        private static readonly Dictionary<(UnitEnum from, UnitEnum to), decimal> ConversionRates =
            new Dictionary<(UnitEnum from, UnitEnum to), decimal>
            {
                { (UnitEnum.g, UnitEnum.kg), 0.001m },
                { (UnitEnum.kg, UnitEnum.g), 1000m },
                { (UnitEnum.ml, UnitEnum.l), 0.001m },
                { (UnitEnum.l, UnitEnum.ml), 1000m }
            };

        public static Measurement ConvertTo(this Measurement source, UnitEnum targetUnit)
        {
            if (source.Unit == targetUnit) return source;

            if (!ConversionRates.TryGetValue((source.Unit, targetUnit), out var factor))
            {
                throw RuleFactory.SimpleRuleException
                    (ErrorCategory.InternalServerError,
                    MeasurementField.Unit,
                    ErrorCode.TypeMismatch,
                    new Dictionary<string, object>
                    {
                        {ParamField.Value,$"{source.Unit} -> {targetUnit}"}
                    });
            }

            var newValue = source.Value * factor;
            return Measurement.Create(newValue, targetUnit);
        }
    }
}