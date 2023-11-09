using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRYINGGGG.Migrations
{
    /// <inheritdoc />
    public partial class AddingAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InventoryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InventoryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "InventoryItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "InventoryItems");
        }
    }
}
