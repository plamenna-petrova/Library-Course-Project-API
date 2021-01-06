using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class updatedFineSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1,
                column: "LibrarianId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibrarianId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibrarianId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1,
                column: "LibrarianId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibrarianId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibrarianId",
                value: null);
        }
    }
}
