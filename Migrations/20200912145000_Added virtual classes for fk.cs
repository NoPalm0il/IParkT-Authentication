using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class Addedvirtualclassesforfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_Utilizadorusername",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Car_CarLicensePlate",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "CarLicensePlate",
                table: "Reservation",
                newName: "carLicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CarLicensePlate",
                table: "Reservation",
                newName: "IX_Reservation_carLicensePlate");

            migrationBuilder.RenameColumn(
                name: "Utilizadorusername",
                table: "Car",
                newName: "utilizadorusername");

            migrationBuilder.RenameIndex(
                name: "IX_Car_Utilizadorusername",
                table: "Car",
                newName: "IX_Car_utilizadorusername");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_utilizadorusername",
                table: "Car",
                column: "utilizadorusername",
                principalTable: "User",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Car_carLicensePlate",
                table: "Reservation",
                column: "carLicensePlate",
                principalTable: "Car",
                principalColumn: "LicensePlate",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_utilizadorusername",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Car_carLicensePlate",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "carLicensePlate",
                table: "Reservation",
                newName: "CarLicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_carLicensePlate",
                table: "Reservation",
                newName: "IX_Reservation_CarLicensePlate");

            migrationBuilder.RenameColumn(
                name: "utilizadorusername",
                table: "Car",
                newName: "Utilizadorusername");

            migrationBuilder.RenameIndex(
                name: "IX_Car_utilizadorusername",
                table: "Car",
                newName: "IX_Car_Utilizadorusername");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_Utilizadorusername",
                table: "Car",
                column: "Utilizadorusername",
                principalTable: "User",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Car_CarLicensePlate",
                table: "Reservation",
                column: "CarLicensePlate",
                principalTable: "Car",
                principalColumn: "LicensePlate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
