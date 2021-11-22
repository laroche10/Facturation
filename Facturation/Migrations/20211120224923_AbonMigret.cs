using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturation.Migrations
{
    public partial class AbonMigret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cni = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    PuissanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnement_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonnement_Puissance_PuissanceId",
                        column: x => x.PuissanceId,
                        principalTable: "Puissance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_CategorieId",
                table: "Abonnement",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_PuissanceId",
                table: "Abonnement",
                column: "PuissanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnement");
        }
    }
}
