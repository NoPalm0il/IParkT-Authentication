using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class addedrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ParkSpot",
                table: "Park");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Reservation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ParkSpotType",
                table: "Park",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GpsCoords",
                table: "Park",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Reservation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParkSpotType",
                table: "Park",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "GpsCoords",
                table: "Park",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ParkSpot",
                table: "Park",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
