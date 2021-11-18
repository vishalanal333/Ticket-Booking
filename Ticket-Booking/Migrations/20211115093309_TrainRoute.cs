using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking.Migrations
{
    public partial class TrainRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(nullable: false),
                    StationName = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRoute", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainRoute");
        }
    }
}
