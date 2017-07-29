using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueData.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorID",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorID",
                table: "Produto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
