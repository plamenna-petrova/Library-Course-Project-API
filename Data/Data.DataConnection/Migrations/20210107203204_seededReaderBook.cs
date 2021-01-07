using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededReaderBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReadersBooks",
                columns: new[] { "BookId", "ReaderId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ReadersBooks",
                columns: new[] { "BookId", "ReaderId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ReadersBooks",
                columns: new[] { "BookId", "ReaderId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReadersBooks",
                keyColumns: new[] { "BookId", "ReaderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ReadersBooks",
                keyColumns: new[] { "BookId", "ReaderId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ReadersBooks",
                keyColumns: new[] { "BookId", "ReaderId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
