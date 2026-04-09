using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Grup2.Migrations
{
    /// <inheritdoc />
    public partial class fm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aracs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelYili = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aracs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmanList_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmanList_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "musteris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "satinalmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    AracID = table.Column<int>(type: "int", nullable: false),
                    AlimFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satinalmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_satinalmas_aracs_AracID",
                        column: x => x.AracID,
                        principalTable: "aracs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_satinalmas_musteris_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "musteris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_satinalmas_AracID",
                table: "satinalmas",
                column: "AracID");

            migrationBuilder.CreateIndex(
                name: "IX_satinalmas_MusteriID",
                table: "satinalmas",
                column: "MusteriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmanList_");

            migrationBuilder.DropTable(
                name: "Products_");

            migrationBuilder.DropTable(
                name: "satinalmas");

            migrationBuilder.DropTable(
                name: "aracs");

            migrationBuilder.DropTable(
                name: "musteris");
        }
    }
}
