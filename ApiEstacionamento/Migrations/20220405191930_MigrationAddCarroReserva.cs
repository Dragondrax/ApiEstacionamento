using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstacionamento.Migrations
{
    public partial class MigrationAddCarroReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Carro_Id",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Carro_Id",
                table: "Reservas",
                column: "Carro_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Carros_Carro_Id",
                table: "Reservas",
                column: "Carro_Id",
                principalTable: "Carros",
                principalColumn: "Id_Carro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Carros_Carro_Id",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_Carro_Id",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Carro_Id",
                table: "Reservas");
        }
    }
}
