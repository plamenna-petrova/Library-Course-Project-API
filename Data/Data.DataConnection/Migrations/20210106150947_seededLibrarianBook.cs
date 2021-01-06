using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededLibrarianBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LibrariansBooks",
                columns: new[] { "BookId", "LibrarianId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LibrariansBooks",
                keyColumns: new[] { "BookId", "LibrarianId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LibrariansBooks",
                keyColumns: new[] { "BookId", "LibrarianId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "LibrariansBooks",
                keyColumns: new[] { "BookId", "LibrarianId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "LibrariansBooks",
                keyColumns: new[] { "BookId", "LibrarianId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LibrariansBooks",
                keyColumns: new[] { "BookId", "LibrarianId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
