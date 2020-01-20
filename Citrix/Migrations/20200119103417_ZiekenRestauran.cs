using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Migrations
{
    public partial class ZiekenRestauran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZiekModel_Restaurant_RestaurantId",
                table: "ZiekModel");

            migrationBuilder.DropIndex(
                name: "IX_ZiekModel_RestaurantId",
                table: "ZiekModel");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ZiekModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ZiekModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZiekModel_RestaurantId",
                table: "ZiekModel",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZiekModel_Restaurant_RestaurantId",
                table: "ZiekModel",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
