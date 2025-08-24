using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects.Common;
using Inventory.Domain.ValueObjects.Ingredients;
using Inventory.Domain.ValueObjects.Inventory;
using Inventory.Domain.ValueObjects.StockReceipt;
using Inventory.Domain.ValueObjects.Unit;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Infrastructure.Persitence.EntityConfigurations
{
    public static class InventoryConverters
    {
        // Unit
        public static readonly ValueConverter<UnitName, string>
            UnitNameConverter = new(v => v.Value, v => UnitName.Create(v));

        // StockReceipt
        public static readonly ValueConverter<Supplier, string>
            SupplierConverter = new(v => v.Value, v => Supplier.Create(v));

        // Ingredients
        public static readonly ValueConverter<IngredientsName, string>
            IngredientsNameConverter = new(v => v.Value, v => IngredientsName.Create(v));

        // Common
        public static readonly ValueConverter<Quantity, decimal>
            QuantityConverter = new(v => v.Value, v => Quantity.Create(v));

        // Inventory
        public static readonly ValueConverter<Capacity, decimal>
            CapacityConverter = new(v => v.Value, v => Capacity.Create(v));

        public static readonly ValueConverter<InventoryStatus, int>
            InventoryStatusConverter = new(v => (int)v.Value, v => InventoryStatus.Create((InventoryStatusEnum)v));
    }
}