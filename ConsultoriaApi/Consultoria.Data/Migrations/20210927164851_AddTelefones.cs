using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultoria.Data.Migrations
{
    public partial class AddTelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "TbCliente");

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.ClienteId, x.Numero });
                    table.ForeignKey(
                        name: "FK_Telefones_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "TbCliente",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
