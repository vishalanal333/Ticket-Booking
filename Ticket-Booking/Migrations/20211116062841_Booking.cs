using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(nullable: false),
                    TravellerName = table.Column<string>(nullable: true),
                    TravellerAge = table.Column<int>(nullable: false),
                    SourceStation = table.Column<string>(nullable: true),
                    DestinationStation = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.TicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
