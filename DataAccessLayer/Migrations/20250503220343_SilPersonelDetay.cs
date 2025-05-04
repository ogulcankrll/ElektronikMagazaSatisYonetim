using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SilPersonelDetay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelDetay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonelDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelDetay_Personel_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDetay_PersonelID",
                table: "PersonelDetay",
                column: "PersonelID",
                unique: true);
        }
    }
}
