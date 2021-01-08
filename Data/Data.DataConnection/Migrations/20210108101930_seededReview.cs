using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class seededReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "CreatedAt", "DeletedAt", "HeadLine", "ModifiedAt", "Rating", "ReviewText", "ReviewerId" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Queen's Gambit Book Review", null, 9, "The Queen's Gambit'' is a novel about the game of chess - the best one that I know of to be written since Nabokov's ''Defense.'' Consider it as a psychological thriller, a contest pitting human rationality against the self's unconscious urge to wipe out thought.", 2 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "CreatedAt", "DeletedAt", "HeadLine", "ModifiedAt", "Rating", "ReviewText", "ReviewerId" },
                values: new object[] { 2, 2, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Castle Book Review", null, 10, "Along with The Trial and Amerika, The Castle is one of the novels Franz Kafka left unfinished at his death. A tale of bureaucratic paralysis, invisible barriers and a labyrinth of obstacles that splinter into more obstacles, The Castle unnerves with its depiction of a pointless, frustrating existence.", 1 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "CreatedAt", "DeletedAt", "HeadLine", "ModifiedAt", "Rating", "ReviewText", "ReviewerId" },
                values: new object[] { 3, 3, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Amazing Adventures of Kavalier and Clay Review", null, 8, "Comic books and magic tricks can mean more that just ballooning muscles and gag gifts - or so Michael Chabon thinks, as he brings us to a time and place where intellect and mystery find their way into these two often overlooked art forms. Jewish mysticism meets Americana in his novel The Amazing Adventures of Kavalier and Clay, and we find all this in the comic-book superhero, the Escapist, who is the creation of the wonderful pair of Joe Kavalier and Sam Clay.", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
