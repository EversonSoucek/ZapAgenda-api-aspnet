using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunasMunicipioeEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Empresa_EmpresaIdEmpresa",
                table: "Estado");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Empresa_EmpresaIdEmpresa",
                table: "Municipio");

            migrationBuilder.DropIndex(
                name: "IX_Municipio_EmpresaIdEmpresa",
                table: "Municipio");

            migrationBuilder.DropIndex(
                name: "IX_Estado_EmpresaIdEmpresa",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "EmpresaIdEmpresa",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "EmpresaIdEmpresa",
                table: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "EstadoUf",
                table: "Empresa",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Empresa",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_EstadoUf",
                table: "Empresa",
                column: "EstadoUf");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_MunicipioId",
                table: "Empresa",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Estado_EstadoUf",
                table: "Empresa",
                column: "EstadoUf",
                principalTable: "Estado",
                principalColumn: "Uf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Municipio_MunicipioId",
                table: "Empresa",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Estado_EstadoUf",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Municipio_MunicipioId",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_EstadoUf",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_MunicipioId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EstadoUf",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Empresa");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaIdEmpresa",
                table: "Municipio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaIdEmpresa",
                table: "Estado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_EmpresaIdEmpresa",
                table: "Municipio",
                column: "EmpresaIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_EmpresaIdEmpresa",
                table: "Estado",
                column: "EmpresaIdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Empresa_EmpresaIdEmpresa",
                table: "Estado",
                column: "EmpresaIdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Empresa_EmpresaIdEmpresa",
                table: "Municipio",
                column: "EmpresaIdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");
        }
    }
}
