using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleBooksRepository.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ExampleBooksApp");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "ExampleBooksApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DayOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "ExampleBooksApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "ExampleBooksApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    PublisherId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "ExampleBooksApp",
                        principalTable: "Author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "ExampleBooksApp",
                        principalTable: "Publisher",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "ExampleBooksApp",
                table: "Author",
                columns: new[] { "Id", "DayOfBirth", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saskia", "Esseintes", "des" },
                    { 2, new DateTime(1987, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matilda", "Mal", "du" },
                    { 3, new DateTime(1989, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juliette", "Wolpertinger", "" }
                });

            migrationBuilder.InsertData(
                schema: "ExampleBooksApp",
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White Seal Publishing" },
                    { 2, "Penguin Publishing Inc." },
                    { 3, "Artic Publishing" }
                });

            migrationBuilder.InsertData(
                schema: "ExampleBooksApp",
                table: "Book",
                columns: new[] { "Id", "AuthorId", "DateCreated", "Description", "ISBN", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "learning the basics of programming.", "1234567890", 1, "Programming basics" },
                    { 2, 2, new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Learning the essentials of Docker and Docker-Compose.", "1234567891", 2, "Docker Essentials" },
                    { 3, 3, new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "For all of those with nostalgic feelings.", "1234567893", 3, "Old School PHP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "ExampleBooksApp",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                schema: "ExampleBooksApp",
                table: "Book",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "ExampleBooksApp");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "ExampleBooksApp");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "ExampleBooksApp");
        }
    }
}
