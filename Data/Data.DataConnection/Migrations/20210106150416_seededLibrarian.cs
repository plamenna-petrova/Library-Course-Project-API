using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededLibrarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LibrarianFirstName", "LibrarianLastName", "LibraryManagingDirectorId", "ModifiedAt" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mark", "Watson", null, null });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LibrarianFirstName", "LibrarianLastName", "LibraryManagingDirectorId", "ModifiedAt" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jake", "Miller", null, null });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LibrarianFirstName", "LibrarianLastName", "LibraryManagingDirectorId", "ModifiedAt" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "David", "Bradford", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
