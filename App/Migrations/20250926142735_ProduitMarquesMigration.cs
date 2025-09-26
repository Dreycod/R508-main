using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class ProduitMarquesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduit",
                table: "TypeProduit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marque",
                table: "Marque");

            migrationBuilder.RenameTable(
                name: "TypeProduit",
                newName: "TypeProduits");

            migrationBuilder.RenameTable(
                name: "Marque",
                newName: "Marques");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduits",
                table: "TypeProduits",
                column: "id_type_produit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marques",
                table: "Marques",
                column: "id_marque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduits",
                table: "TypeProduits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marques",
                table: "Marques");

            migrationBuilder.RenameTable(
                name: "TypeProduits",
                newName: "TypeProduit");

            migrationBuilder.RenameTable(
                name: "Marques",
                newName: "Marque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduit",
                table: "TypeProduit",
                column: "id_type_produit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marque",
                table: "Marque",
                column: "id_marque");
        }
    }
}
