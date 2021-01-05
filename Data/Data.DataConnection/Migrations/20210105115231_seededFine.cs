using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededFine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FineDescription", "FineFee", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prolonged return of the book", 5.00m, null, null, null });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FineDescription", "FineFee", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Not payed library fee", 5.25m, null, null, null });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FineDescription", "FineFee", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stolen book from library", 10.50m, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
