using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "CreatedAt", "DateToReturn", "DeletedAt", "IsActiveLoan", "IssueDate", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "CreatedAt", "DateToReturn", "DeletedAt", "IsActiveLoan", "IssueDate", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 2, 2, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "CreatedAt", "DateToReturn", "DeletedAt", "IsActiveLoan", "IssueDate", "LibrarianId", "ModifiedAt", "ReaderId" },
                values: new object[] { 3, 3, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
