using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class ajustaforeignkeyUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empresa_EmpresaIdEmpresa",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpresaIdEmpresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmpresaIdEmpresa",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdEmpresa",
                table: "AspNetUsers",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empresa_IdEmpresa",
                table: "AspNetUsers",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empresa_IdEmpresa",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdEmpresa",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaIdEmpresa",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpresaIdEmpresa",
                table: "AspNetUsers",
                column: "EmpresaIdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empresa_EmpresaIdEmpresa",
                table: "AspNetUsers",
                column: "EmpresaIdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
