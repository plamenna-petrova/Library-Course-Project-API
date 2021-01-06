using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededLibraryManagingDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LibraryManagingDirectors",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LibraryManagingDirectorFirstName", "LibraryManagingDirectorLastName", "ModifiedAt", "WorkingExperienceInYears" },
                values: new object[] { 1, new DateTime(2021, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Caleb", "Owen", null, 4 });

            migrationBuilder.InsertData(
                table: "LibraryManagingDirectors",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "LibraryManagingDirectorFirstName", "LibraryManagingDirectorLastName", "ModifiedAt", "WorkingExperienceInYears" },
                values: new object[] { 2, new DateTime(2021, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anne", "Griffin", null, 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LibraryManagingDirectors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LibraryManagingDirectors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
