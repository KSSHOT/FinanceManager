using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Finanzas_CategoriaId",
                table: "Finanzas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finanzas_Categorias_CategoriaId",
                table: "Finanzas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finanzas_Categorias_CategoriaId",
                table: "Finanzas");

            migrationBuilder.DropIndex(
                name: "IX_Finanzas_CategoriaId",
                table: "Finanzas");
        }
    }
}
