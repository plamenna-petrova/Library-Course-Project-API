using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class AddedSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorBiography", "AuthorFirstName", "AuthorLastName", "CountryId", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, "Born in the USA...", "Walter", "Tevis", null, new DateTime(2020, 11, 21, 20, 49, 24, 186, DateTimeKind.Local).AddTicks(8005), null, null },
                    { 2, "Born in Prague, Czech Republic", "Franz", "Kafka", null, new DateTime(2020, 11, 21, 20, 49, 24, 189, DateTimeKind.Local).AddTicks(992), null, null },
                    { 3, "Modern American author", "Michael", "Chabon", null, new DateTime(2020, 11, 21, 20, 49, 24, 189, DateTimeKind.Local).AddTicks(1028), null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookAnnotation", "BookEdition", "BookPages", "BookTitle", "CreatedAt", "DatePublished", "DeletedAt", "ISBN", "ModifiedAt", "PublisherId" },
                values: new object[,]
                {
                    { 1, "A story about an young chess player Beth Harmon and her struggles with defining her self in the chess world", "third", 243, "The Queen's Gambit", new DateTime(2020, 11, 21, 20, 49, 24, 189, DateTimeKind.Local).AddTicks(4231), new DateTime(1983, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "978-3-16-148410-0", null, null },
                    { 2, "Kafka's unsurmounted masterpiece!", "first", 302, "The Castle", new DateTime(2020, 11, 21, 20, 49, 24, 189, DateTimeKind.Local).AddTicks(4323), new DateTime(1926, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1004-3-16-148410-0", null, null },
                    { 3, "Michael Chabon's Pulitzer winning work!", "second", 705, "The Amazing Adventures of Kavalier and Clay", new DateTime(2020, 11, 21, 20, 49, 24, 189, DateTimeKind.Local).AddTicks(4330), new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "834-3-16-148410-0", null, null }
                });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
