using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MappingDemo.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    StarRating = table.Column<double>(type: "REAL", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "FirstName", "LastName", "StarRating" },
                values: new object[] { 1, new DateTime(1908, 5, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Ian", "Flemming", 4.9100000000000001 });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "FirstName", "LastName", "StarRating" },
                values: new object[] { 2, new DateTime(1931, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "John", "le Carré", 4.0099999999999998 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 1, 1, "Casino Royale", 1953 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 2, 1, "Live and Let Die", 1954 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 3, 1, "Moonraker", 1955 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 4, 1, "Diamonds Are Forever", 1956 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 5, 1, "From Russia, with Love", 1957 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 6, 1, "Dr. No", 1958 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 7, 2, "Call for the Dead", 1961 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 8, 2, "A Murder of Quality", 1962 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 9, 2, "The Spy Who Came In from the Cold", 1963 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 10, 2, "The Looking Glass War", 1965 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 11, 2, "Tinker Tailor Soldier Spy", 1974 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 12, 2, "The Honourable Schoolboy", 1977 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Title", "Year" },
                values: new object[] { 13, 2, "Smiley's People", 1979 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
