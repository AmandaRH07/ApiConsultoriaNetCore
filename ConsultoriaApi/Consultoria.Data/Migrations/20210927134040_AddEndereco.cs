using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultoria.Data.Migrations
{
    public partial class AddEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TbCliente",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Endereco_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_Nome_Sexo",
                table: "TbCliente",
                columns: new[] { "Nome", "Sexo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

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
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldDefaultValue: "F");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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
        }
    }
}
