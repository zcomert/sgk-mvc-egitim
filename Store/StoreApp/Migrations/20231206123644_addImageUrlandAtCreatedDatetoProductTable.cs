using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class addImageUrlandAtCreatedDatetoProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtCreatedDate",
                table: "Products",
                type: "TEXT",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 6, 15, 37, 44, 639, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "TEXT",
                nullable: true,
                defaultValue: "/images/default.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "AtCreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 12, 6, 15, 37, 44, 639, DateTimeKind.Local).AddTicks(9075), "/images/default.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "AtCreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 12, 6, 15, 37, 44, 639, DateTimeKind.Local).AddTicks(9083), "/images/default.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "AtCreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 12, 6, 15, 37, 44, 639, DateTimeKind.Local).AddTicks(9084), "/images/default.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtCreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");
        }
    }
}
