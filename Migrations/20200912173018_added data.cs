using Microsoft.EntityFrameworkCore.Migrations;

namespace IParkT_Authentication.Migrations
{
    public partial class addeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Park",
                columns: new[] { "ParkId", "GpsCoords", "ParkSpotType" },
                values: new object[,]
                {
                    { 4, "39°36'01.8\"N 8°23'29.3\"W", "Teacher" },
                    { 5, "39°36'01.8\"N 8°23'29.3\"W", "Aux" },
                    { 6, "39°36'01.8\"N 8°23'29.3\"W", "Aux" },
                    { 7, "39°36'01.8\"N 8°23'29.3\"W", "Student" },
                    { 8, "39°36'01.8\"N 8°23'29.3\"W", "Student" },
                    { 9, "39°36'01.8\"N 8°23'29.3\"W", "Student" },
                    { 10, "39°36'01.8\"N 8°23'29.3\"W", "Student" },
                    { 11, "39°36'01.8\"N 8°23'29.3\"W", "Student" },
                    { 12, "39°36'01.8\"N 8°23'29.3\"W", "Principal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ParkId",
                keyValue: 12);
        }
    }
}
