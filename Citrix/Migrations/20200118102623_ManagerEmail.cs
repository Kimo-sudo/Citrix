using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Migrations
{
    public partial class ManagerEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Manager",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Manager");
        }
    }
}
