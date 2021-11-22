using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturation.Migrations
{
    public partial class AjoutFact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Categorie",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Facturations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_facture = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Montant_hors_taxe = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Montant_ttc = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TvaId = table.Column<int>(type: "int", nullable: false),
                    AbonnementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturations_Abonnement_AbonnementId",
                        column: x => x.AbonnementId,
                        principalTable: "Abonnement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturations_Tva_TvaId",
                        column: x => x.TvaId,
                        principalTable: "Tva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturations_AbonnementId",
                table: "Facturations",
                column: "AbonnementId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturations_TvaId",
                table: "Facturations",
                column: "TvaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturations");

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Categorie",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
