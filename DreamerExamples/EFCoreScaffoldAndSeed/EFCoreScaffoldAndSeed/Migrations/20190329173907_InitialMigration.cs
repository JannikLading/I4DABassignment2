using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreScaffoldAndSeed.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => new { x.FirstName, x.LastName });
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN10 = table.Column<int>(nullable: false),
                    ISBN13 = table.Column<string>(maxLength: 20, nullable: false),
                    price = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    publishedOn = table.Column<DateTime>(nullable: false),
                    imgurl = table.Column<string>(nullable: true),
                    Pages = table.Column<int>(nullable: false),
                    PrimaryAuthor = table.Column<string>(nullable: true),
                    NextInSeriesISBN10 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN10);
                    table.UniqueConstraint("AlternateKey_ISBN13_UniqueConstraint", x => x.ISBN13);
                    table.ForeignKey(
                        name: "FK_Books_Books_NextInSeriesISBN10",
                        column: x => x.NextInSeriesISBN10,
                        principalTable: "Books",
                        principalColumn: "ISBN10",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookAuhtorId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ISBN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookAuhtorId, x.FirstName, x.LastName });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN10",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_FirstName_LastName",
                        columns: x => new { x.FirstName, x.LastName },
                        principalTable: "Authors",
                        principalColumns: new[] { "FirstName", "LastName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    EditionId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ISBN10 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.EditionId);
                    table.ForeignKey(
                        name: "FK_Edition_Books_ISBN10",
                        column: x => x.ISBN10,
                        principalTable: "Books",
                        principalColumn: "ISBN10",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewPrice = table.Column<int>(nullable: false),
                    BookISBN = table.Column<int>(nullable: false),
                    PromotionText = table.Column<string>(nullable: true),
                    BookISBN10 = table.Column<int>(nullable: true),
                    ISBN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceOffers_Books_BookISBN10",
                        column: x => x.BookISBN10,
                        principalTable: "Books",
                        principalColumn: "ISBN10",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumStars = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    VoterName = table.Column<string>(nullable: false),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    BookISBN10 = table.Column<int>(nullable: true),
                    ISBN = table.Column<int>(nullable: false),
                    EditionId1 = table.Column<string>(nullable: true),
                    EditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Books_BookISBN10",
                        column: x => x.BookISBN10,
                        principalTable: "Books",
                        principalColumn: "ISBN10",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Edition_EditionId1",
                        column: x => x.EditionId1,
                        principalTable: "Edition",
                        principalColumn: "EditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voter",
                columns: table => new
                {
                    Firstname = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ReviewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter", x => new { x.Firstname, x.LastName });
                    table.ForeignKey(
                        name: "FK_Voter_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "FirstName", "LastName", "ImageUrl" },
                values: new object[] { "HasDataFName", "HasDataLName", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN10", "ISBN13", "NextInSeriesISBN10", "Pages", "PrimaryAuthor", "description", "imgurl", "price", "publishedOn", "title" },
                values: new object[] { 1212121212, "01234567890123456789", null, 0, null, null, null, 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TheHasDataBook" });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookAuhtorId", "FirstName", "LastName", "ISBN" },
                values: new object[] { 0, "HasDataFName", "HasDataLName", 1212121212 });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_ISBN",
                table: "BookAuthors",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_FirstName_LastName",
                table: "BookAuthors",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_NextInSeriesISBN10",
                table: "Books",
                column: "NextInSeriesISBN10");

            migrationBuilder.CreateIndex(
                name: "IX_Edition_ISBN10",
                table: "Edition",
                column: "ISBN10");

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffers_BookISBN10",
                table: "PriceOffers",
                column: "BookISBN10");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookISBN10",
                table: "Review",
                column: "BookISBN10");

            migrationBuilder.CreateIndex(
                name: "IX_Review_EditionId1",
                table: "Review",
                column: "EditionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_ReviewId",
                table: "Voter",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "PriceOffers");

            migrationBuilder.DropTable(
                name: "Voter");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Edition");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
