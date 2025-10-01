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
            // 1. Drop foreign keys that depend on the old tables
            migrationBuilder.DropForeignKey(
                name: "FK_produits_marque",
                table: "produit");

            migrationBuilder.DropForeignKey(
                name: "FK_produits_type_produit",
                table: "produit");

            // 2. Drop primary keys on old tables
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduit",
                table: "TypeProduit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marque",
                table: "Marque");

            // 3. Rename tables
            migrationBuilder.RenameTable(
                name: "TypeProduit",
                newName: "TypeProduits");

            migrationBuilder.RenameTable(
                name: "Marque",
                newName: "Marques");

            // 4. Add primary keys on new tables
            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduits",
                table: "TypeProduits",
                column: "id_type_produit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marques",
                table: "Marques",
                column: "id_marque");

            // 5. Recreate foreign keys on produit referencing the new table names
            migrationBuilder.AddForeignKey(
                name: "FK_produits_Marques",
                table: "produit",
                column: "id_marque",
                principalTable: "Marques",
                principalColumn: "id_marque",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produits_TypeProduits",
                table: "produit",
                column: "id_type_produit",
                principalTable: "TypeProduits",
                principalColumn: "id_type_produit",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign keys referencing the renamed tables
            migrationBuilder.DropForeignKey(
                name: "FK_produits_Marques",
                table: "produit");

            migrationBuilder.DropForeignKey(
                name: "FK_produits_TypeProduits",
                table: "produit");

            // Drop PKs on renamed tables
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduits",
                table: "TypeProduits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marques",
                table: "Marques");

            // Rename tables back to original names
            migrationBuilder.RenameTable(
                name: "TypeProduits",
                newName: "TypeProduit");

            migrationBuilder.RenameTable(
                name: "Marques",
                newName: "Marque");

            // Add original PKs
            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduit",
                table: "TypeProduit",
                column: "id_type_produit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marque",
                table: "Marque",
                column: "id_marque");

            // Recreate foreign keys referencing original tables
            migrationBuilder.AddForeignKey(
                name: "FK_produits_marque",
                table: "produit",
                column: "id_marque",
                principalTable: "Marque",
                principalColumn: "id_marque",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produits_type_produit",
                table: "produit",
                column: "id_type_produit",
                principalTable: "TypeProduit",
                principalColumn: "id_type_produit",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
