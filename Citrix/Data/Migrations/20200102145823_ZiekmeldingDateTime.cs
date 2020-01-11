using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Citrix.Data.Migrations
{
    public partial class ZiekmeldingDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DagZiek",
                table: "ZiekModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DagZiek",
                table: "ZiekModel");
        }
    }
}
