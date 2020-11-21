using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class removedManyToManyKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ReadersLibrarians");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ReadersLibrarians");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReadersLibrarians");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ReadersLibrarians");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ReadersBooks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ReadersBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReadersBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ReadersBooks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "LibrariansBooks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "LibrariansBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LibrariansBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "LibrariansBooks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BooksReviewers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BooksReviewers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BooksReviewers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "BooksReviewers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BooksGenres");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BooksGenres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BooksGenres");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "BooksGenres");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BooksAuthors");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BooksAuthors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BooksAuthors");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "BooksAuthors");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AuthorsPublishers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AuthorsPublishers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorsPublishers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AuthorsPublishers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ReadersLibrarians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ReadersLibrarians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReadersLibrarians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ReadersLibrarians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ReadersBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ReadersBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReadersBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ReadersBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "LibrariansBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "LibrariansBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LibrariansBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "LibrariansBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BooksReviewers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BooksReviewers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BooksReviewers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "BooksReviewers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BooksGenres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BooksGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BooksGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "BooksGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BooksAuthors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BooksAuthors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BooksAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "BooksAuthors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AuthorsPublishers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AuthorsPublishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuthorsPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AuthorsPublishers",
                type: "datetime2",
                nullable: true);
        }
    }
}
