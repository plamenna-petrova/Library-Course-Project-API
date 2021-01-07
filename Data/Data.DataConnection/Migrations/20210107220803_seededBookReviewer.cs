using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededBookReviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BooksReviewers",
                columns: new[] { "BookId", "ReviewerId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "BooksReviewers",
                columns: new[] { "BookId", "ReviewerId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "BooksReviewers",
                columns: new[] { "BookId", "ReviewerId" },
                values: new object[] { 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksReviewers",
                keyColumns: new[] { "BookId", "ReviewerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BooksReviewers",
                keyColumns: new[] { "BookId", "ReviewerId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "BooksReviewers",
                keyColumns: new[] { "BookId", "ReviewerId" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
