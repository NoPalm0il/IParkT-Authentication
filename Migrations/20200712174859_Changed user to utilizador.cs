using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class Changedusertoutilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_username",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_username",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "Utilizadorusername",
                table: "Car",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_Utilizadorusername",
                table: "Car",
                column: "Utilizadorusername");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_Utilizadorusername",
                table: "Car",
                column: "Utilizadorusername",
                principalTable: "User",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_Utilizadorusername",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_Utilizadorusername",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Utilizadorusername",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Car",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_username",
                table: "Car",
                column: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_username",
                table: "Car",
                column: "username",
                principalTable: "User",
                principalColumn: "username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
