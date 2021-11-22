using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturation.Migrations
{
    public partial class OneMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayementDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abonnement",
                table: "Abonnement");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Abonnement",
                newName: "Puissance");

            migrationBuilder.RenameColumn(
                name: "Valeur",
                table: "Categorie",
                newName: "Libelle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puissance",
                table: "Puissance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tva", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puissance",
                table: "Puissance");

            migrationBuilder.RenameTable(
                name: "Puissance",
                newName: "Abonnement");

            migrationBuilder.RenameColumn(
                name: "Libelle",
                table: "Categorie",
                newName: "Valeur");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Categorie",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abonnement",
                table: "Abonnement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PayementDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementDetail", x => x.Id);
                });
        }
    }
}
