using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class newBooksSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookAnnotation", "BookEdition", "BookPages", "BookTitle", "CreatedAt", "DatePublished", "DeletedAt", "ISBN", "ModifiedAt", "PublisherId" },
                values: new object[] { 4, "Test Book", "third", 345, "Test Book", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "456-2-17-351289-0", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: null);
        }
    }
}
