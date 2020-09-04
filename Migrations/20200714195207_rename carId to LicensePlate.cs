using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class renamecarIdtoLicensePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "LicensePlate",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
