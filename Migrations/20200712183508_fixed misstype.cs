using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class fixedmisstype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "username",
                table: "Car",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
