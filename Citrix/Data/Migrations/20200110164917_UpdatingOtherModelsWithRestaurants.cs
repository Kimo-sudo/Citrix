using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Data.Migrations
{
    public partial class UpdatingOtherModelsWithRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ZiekModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantModelId",
                table: "Manager",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Dagdeel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZiekModel_RestaurantId",
                table: "ZiekModel",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Dagdeel_RestaurantId",
                table: "Dagdeel",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dagdeel_Restaurant_RestaurantId",
                table: "Dagdeel",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager",
                column: "RestaurantModelId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZiekModel_Restaurant_RestaurantId",
                table: "ZiekModel",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dagdeel_Restaurant_RestaurantId",
                table: "Dagdeel");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Restaurant_RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_ZiekModel_Restaurant_RestaurantId",
                table: "ZiekModel");

            migrationBuilder.DropIndex(
                name: "IX_ZiekModel_RestaurantId",
                table: "ZiekModel");

            migrationBuilder.DropIndex(
                name: "IX_Manager_RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Dagdeel_RestaurantId",
                table: "Dagdeel");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ZiekModel");

            migrationBuilder.DropColumn(
                name: "RestaurantModelId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Dagdeel");
        }
    }
}
