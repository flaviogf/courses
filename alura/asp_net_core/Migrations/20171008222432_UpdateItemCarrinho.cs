using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace casa_do_codigo_core.Migrations
{
    public partial class UpdateItemCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "ItensCarrinho",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "ItensCarrinho",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCarrinho_Produtos_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
