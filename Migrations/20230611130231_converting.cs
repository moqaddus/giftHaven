using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRYINGGGG.Migrations
{
    /// <inheritdoc />
    public partial class converting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Category = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Picture = table.Column<byte[]>(type: "image", nullable: true),
                    imagePath = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    totalAmount = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Zip = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNN = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    CVV = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderItems_ToInventory",
                        column: x => x.ItemId,
                        principalTable: "InventoryItems",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_OrderItems_ToOrders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
