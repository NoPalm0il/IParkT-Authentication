using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class nonnullvalueparid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Park_ParkId",
                table: "Reservation",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
