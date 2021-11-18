using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking.Migrations
{
    public partial class Train : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainName = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.TrainId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
