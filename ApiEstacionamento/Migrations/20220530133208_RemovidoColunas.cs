using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstacionamento.Migrations
{
    public partial class RemovidoColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Tipo_Veiculo",
                table: "Carros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Veiculo",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
