using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Data.Migrations
{
    public partial class Hopelijk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Manager_RestManagerID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_RestManagerID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestManagerID",
                table: "Restaurant");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantModelId",
                table: "Manager",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager");

            migrationBuilder.AddColumn<int>(
                name: "RestManagerID",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantModelId",
                table: "Manager",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestManagerID",
                table: "Restaurant",
                column: "RestManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Manager_RestManagerID",
                table: "Restaurant",
                column: "RestManagerID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
