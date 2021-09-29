using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultoria.Data.Migrations
{
    public partial class enumsexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_TbCliente_ClienteId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_TbCliente_ClienteId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbCliente",
                table: "TbCliente");

            migrationBuilder.DropIndex(
                name: "IX_TbCliente_Nome_Sexo",
                table: "TbCliente");

            migrationBuilder.RenameTable(
                name: "TbCliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "DocumentoIdentificador",
                table: "Clientes",
                newName: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldDefaultValue: "F");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(48)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Clientes_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Clientes_ClienteId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "TbCliente");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "TbCliente",
                newName: "DocumentoIdentificador");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "TbCliente",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "F",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "TbCliente",
                type: "varchar(48)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbCliente",
                table: "TbCliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_Nome_Sexo",
                table: "TbCliente",
                columns: new[] { "Nome", "Sexo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_TbCliente_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_TbCliente_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
