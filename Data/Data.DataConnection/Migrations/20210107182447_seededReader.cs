using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "HasPayedTheLibraryFee", "LibraryFee", "ModifiedAt", "ReaderAddress", "ReaderAge", "ReaderCity", "ReaderContactNumber", "ReaderEmail", "ReaderFirstName", "ReaderLastName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 5.00m, null, "Seagull Street 16, Downtown Manhattan", 17, "New York", 120256778, "elpark@gmail.com", "Elliot", "Parker" });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "HasPayedTheLibraryFee", "LibraryFee", "ModifiedAt", "ReaderAddress", "ReaderAge", "ReaderCity", "ReaderContactNumber", "ReaderEmail", "ReaderFirstName", "ReaderLastName" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7.50m, null, "Beacon Street 52, Lower East Side", 20, "New York", 123555676, "jvern678@gmail.com", "Jolyne", "Vernon" });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "HasPayedTheLibraryFee", "LibraryFee", "ModifiedAt", "ReaderAddress", "ReaderAge", "ReaderCity", "ReaderContactNumber", "ReaderEmail", "ReaderFirstName", "ReaderLastName" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 4.50m, null, "Canyon Street 84, Harlem", 63, "New York", 124567789, "frank_waters36@gmail.com", "Frank", "Waters" });

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReaderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReaderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReaderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReaderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReaderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReaderId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReaderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReaderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReaderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReaderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReaderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReaderId",
                value: null);
        }
    }
}
