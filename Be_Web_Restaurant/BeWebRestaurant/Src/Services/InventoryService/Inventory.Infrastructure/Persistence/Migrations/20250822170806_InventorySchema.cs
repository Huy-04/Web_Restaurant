using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InventorySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodRecipe",
                columns: table => new
                {
                    IdFoodRecipe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipe", x => x.IdFoodRecipe);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IdIngredients = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IdIngredients);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    IdInventory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InventoryStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.IdInventory);
                });

            migrationBuilder.CreateTable(
                name: "StockReceipt",
                columns: table => new
                {
                    IdStockReceipt = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Importdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockReceipt", x => x.IdStockReceipt);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    IdUnit = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.IdUnit);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipe_FoodId",
                table: "FoodRecipe",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipe_IngredientsId",
                table: "FoodRecipe",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientsName",
                table: "Ingredients",
                column: "IngredientsName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_IngredientsId",
                table: "Inventory",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_StockReceipt_IngredientsId",
                table: "StockReceipt",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UnitName",
                table: "Unit",
                column: "UnitName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecipe");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "StockReceipt");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
