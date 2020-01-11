using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Data.Migrations
{
    public partial class First1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerIdBeterGemeldID",
                table: "ZiekModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerIdZiekGemeldID",
                table: "ZiekModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZiekModel_ManagerIdBeterGemeldID",
                table: "ZiekModel",
                column: "ManagerIdBeterGemeldID");

            migrationBuilder.CreateIndex(
                name: "IX_ZiekModel_ManagerIdZiekGemeldID",
                table: "ZiekModel",
                column: "ManagerIdZiekGemeldID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZiekModel_Manager_ManagerIdBeterGemeldID",
                table: "ZiekModel",
                column: "ManagerIdBeterGemeldID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZiekModel_Manager_ManagerIdZiekGemeldID",
                table: "ZiekModel",
                column: "ManagerIdZiekGemeldID",
                principalTable: "Manager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}