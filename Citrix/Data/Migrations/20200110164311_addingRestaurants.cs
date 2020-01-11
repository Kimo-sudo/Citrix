using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Data.Migrations
{
    public partial class addingRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true),
                    RestManagerID = table.Column<int>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    TelefoonNummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_Manager_RestManagerID",
                        column: x => x.RestManagerID,
                        principalTable: "Manager",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestManagerID",
                table: "Restaurant",
                column: "RestManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
