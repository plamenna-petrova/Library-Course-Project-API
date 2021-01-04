using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededBookImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "BookImageShortDecsription", "BookImageUrl", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[] { 1, 1, "Queen's Gambit image", "/images/bookImage1.jpg", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "BookImageShortDecsription", "BookImageUrl", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[] { 2, 2, "The Castle image", "/images/bookImage2.jpg", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "BookImageShortDecsription", "BookImageUrl", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[] { 3, 3, "The Amazing Adventures of Kavalier and Clay image", "/images/bookImage3.jpg", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
