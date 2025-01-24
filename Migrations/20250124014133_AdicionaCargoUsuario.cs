using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCargoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cargo_CargoIdCargo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CargoIdCargo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CargoIdCargo",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdCargo",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCargo",
                table: "Usuario",
                column: "IdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cargo_IdCargo",
                table: "Usuario",
                column: "IdCargo",
                principalTable: "Cargo",
                principalColumn: "IdCargo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cargo_IdCargo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdCargo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdCargo",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "CargoIdCargo",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CargoIdCargo",
                table: "Usuario",
                column: "CargoIdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cargo_CargoIdCargo",
                table: "Usuario",
                column: "CargoIdCargo",
                principalTable: "Cargo",
                principalColumn: "IdCargo");
        }
    }
}
