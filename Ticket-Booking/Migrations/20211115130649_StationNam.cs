using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking.Migrations
{
    public partial class StationNam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stations");

            migrationBuilder.AddColumn<string>(
                name: "StationCode",
                table: "Stations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "StationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "StationCode",
                table: "Stations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "Id");
        }
    }
}
