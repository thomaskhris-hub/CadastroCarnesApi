using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCarnes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustarDeleteRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Carnes_CarneId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Compradores_CompradorId",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Carnes_CarneId",
                table: "PedidoItens",
                column: "CarneId",
                principalTable: "Carnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Compradores_CompradorId",
                table: "Pedidos",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Carnes_CarneId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Compradores_CompradorId",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Carnes_CarneId",
                table: "PedidoItens",
                column: "CarneId",
                principalTable: "Carnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Compradores_CompradorId",
                table: "Pedidos",
                column: "CompradorId",
                principalTable: "Compradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
