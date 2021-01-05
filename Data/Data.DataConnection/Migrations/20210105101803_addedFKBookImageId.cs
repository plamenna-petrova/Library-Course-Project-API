using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class addedFKBookImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookImageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "BookImageShortDecsription", "BookImageUrl", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[] { 4, 4, "Test Image 4", "/images/bookImage4.jpg", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookImageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookImageId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookImageId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookImageId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookAnnotation", "BookEdition", "BookImageId", "BookPages", "BookTitle", "CreatedAt", "DatePublished", "DeletedAt", "ISBN", "ModifiedAt", "PublisherId" },
                values: new object[] { 5, "Another Test Book", "first", 5, 124, "Another Test Book", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "123-6-18-9786120-0", null, 2 });

            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "BookImageShortDecsription", "BookImageUrl", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[] { 5, 5, "Test Image 5", "/images/bookImage5.jpg", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "BookImageId",
                table: "Books");
        }
    }
}
