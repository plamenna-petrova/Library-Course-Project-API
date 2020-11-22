using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class changedAuthorsPublishersSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorsPublishers",
                keyColumns: new[] { "AuthorId", "PublisherId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 752, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 752, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 752, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.InsertData(
                table: "AuthorsPublishers",
                columns: new[] { "AuthorId", "PublisherId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 749, DateTimeKind.Local).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 751, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 9, 28, 751, DateTimeKind.Local).AddTicks(5656));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorsPublishers",
                keyColumns: new[] { "AuthorId", "PublisherId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 683, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 683, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 683, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.InsertData(
                table: "AuthorsPublishers",
                columns: new[] { "AuthorId", "PublisherId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 680, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 682, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 22, 13, 0, 22, 682, DateTimeKind.Local).AddTicks(6207));
        }
    }
}
