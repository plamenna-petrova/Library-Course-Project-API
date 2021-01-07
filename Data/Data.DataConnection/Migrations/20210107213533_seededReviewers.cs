using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededReviewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "CountryId", "CreatedAt", "DeletedAt", "ModifiedAt", "ReviewerFirstName", "ReviewerLastName" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Seymour", "Thompson" });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "CountryId", "CreatedAt", "DeletedAt", "ModifiedAt", "ReviewerFirstName", "ReviewerLastName" },
                values: new object[] { 2, 3, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Val", "O'Connor" });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "CountryId", "CreatedAt", "DeletedAt", "ModifiedAt", "ReviewerFirstName", "ReviewerLastName" },
                values: new object[] { 3, 2, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Jerome", "Scott Jr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
