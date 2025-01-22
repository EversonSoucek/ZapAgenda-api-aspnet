using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaRelacaoEmpresaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
