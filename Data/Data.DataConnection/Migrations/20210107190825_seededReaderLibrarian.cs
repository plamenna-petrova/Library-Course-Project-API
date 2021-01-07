using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededReaderLibrarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReadersLibrarians",
                columns: new[] { "LibrarianId", "ReaderId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ReadersLibrarians",
                columns: new[] { "LibrarianId", "ReaderId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ReadersLibrarians",
                columns: new[] { "LibrarianId", "ReaderId" },
                values: new object[] { 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReadersLibrarians",
                keyColumns: new[] { "LibrarianId", "ReaderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ReadersLibrarians",
                keyColumns: new[] { "LibrarianId", "ReaderId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ReadersLibrarians",
                keyColumns: new[] { "LibrarianId", "ReaderId" },
                keyValues: new object[] { 1, 3 });
        }
    }
}
