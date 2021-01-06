using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class addedFKLibraryManagingDirectorIdToLibrarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1,
                column: "LibraryManagingDirectorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryManagingDirectorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibraryManagingDirectorId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1,
                column: "LibraryManagingDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 2,
                column: "LibraryManagingDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 3,
                column: "LibraryManagingDirectorId",
                value: null);
        }
    }
}
