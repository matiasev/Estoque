using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstoqueData.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "Produto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FornecedorID",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    FornecedorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Endereco = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.FornecedorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto",
                column: "FornecedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto",
                column: "FornecedorID",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorID",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FornecedorID",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FornecedorID",
                table: "Produto");
        }
    }
}
