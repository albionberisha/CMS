using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAndLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatName);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PubName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PubCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PubName);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    ReaderNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.ReaderNr);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PubYear = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumPages = table.Column<int>(type: "int", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCatName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherPubName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Isbn);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryCatName",
                        column: x => x.CategoryCatName,
                        principalTable: "Categories",
                        principalColumn: "CatName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherPubName",
                        column: x => x.PublisherPubName,
                        principalTable: "Publishers",
                        principalColumn: "PubName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReaderPhoneNumbers",
                columns: table => new
                {
                    ReaderNr = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReaderNr1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderPhoneNumbers", x => new { x.ReaderNr, x.PhoneNumber });
                    table.ForeignKey(
                        name: "FK_ReaderPhoneNumbers_Readers_ReaderNr1",
                        column: x => x.ReaderNr1,
                        principalTable: "Readers",
                        principalColumn: "ReaderNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Copies",
                columns: table => new
                {
                    CopyNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.CopyNr);
                    table.ForeignKey(
                        name: "FK_Copies_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn");
                });

            migrationBuilder.CreateTable(
                name: "InCats",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryCatName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InCats", x => new { x.Isbn, x.CatName });
                    table.ForeignKey(
                        name: "FK_InCats_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn");
                    table.ForeignKey(
                        name: "FK_InCats_Categories_CategoryCatName",
                        column: x => x.CategoryCatName,
                        principalTable: "Categories",
                        principalColumn: "CatName");
                });

            migrationBuilder.CreateTable(
                name: "Publishes",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PubName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PublisherPubName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishes", x => new { x.Isbn, x.PubName });
                    table.ForeignKey(
                        name: "FK_Publishes_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn");
                    table.ForeignKey(
                        name: "FK_Publishes_Publishers_PublisherPubName",
                        column: x => x.PublisherPubName,
                        principalTable: "Publishers",
                        principalColumn: "PubName");
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    ReaderNr = table.Column<int>(type: "int", nullable: false),
                    CopyNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReaderNr1 = table.Column<int>(type: "int", nullable: false),
                    CopyNr1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => new { x.ReaderNr, x.CopyNr });
                    table.ForeignKey(
                        name: "FK_Borrows_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn");
                    table.ForeignKey(
                        name: "FK_Borrows_Copies_CopyNr1",
                        column: x => x.CopyNr1,
                        principalTable: "Copies",
                        principalColumn: "CopyNr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Readers_ReaderNr1",
                        column: x => x.ReaderNr1,
                        principalTable: "Readers",
                        principalColumn: "ReaderNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryCatName",
                table: "Books",
                column: "CategoryCatName");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherPubName",
                table: "Books",
                column: "PublisherPubName");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookIsbn",
                table: "Borrows",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_CopyNr1",
                table: "Borrows",
                column: "CopyNr1");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_ReaderNr1",
                table: "Borrows",
                column: "ReaderNr1");

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookIsbn",
                table: "Copies",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_InCats_BookIsbn",
                table: "InCats",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_InCats_CategoryCatName",
                table: "InCats",
                column: "CategoryCatName");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_BookIsbn",
                table: "Publishes",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_PublisherPubName",
                table: "Publishes",
                column: "PublisherPubName");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderPhoneNumbers_ReaderNr1",
                table: "ReaderPhoneNumbers",
                column: "ReaderNr1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "InCats");

            migrationBuilder.DropTable(
                name: "Publishes");

            migrationBuilder.DropTable(
                name: "ReaderPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Copies");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
