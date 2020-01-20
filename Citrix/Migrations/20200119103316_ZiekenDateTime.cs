using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Migrations
{
    public partial class ZiekenDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Restaurant");

            migrationBuilder.AddColumn<DateTime>(
                name: "DagZiek",
                table: "ZiekModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantModelId",
                table: "Manager",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "DagZiek",
                table: "ZiekModel");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantModelId",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
