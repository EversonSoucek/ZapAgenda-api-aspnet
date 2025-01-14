using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunasEnderecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Empresa",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Empresa",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Empresa",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Empresa",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Uf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaIdEmpresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Uf);
                    table.ForeignKey(
                        name: "FK_Estado_Empresa_EmpresaIdEmpresa",
                        column: x => x.EmpresaIdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    IdMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaIdEmpresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.IdMunicipio);
                    table.ForeignKey(
                        name: "FK_Municipio_Empresa_EmpresaIdEmpresa",
                        column: x => x.EmpresaIdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_EmpresaIdEmpresa",
                table: "Estado",
                column: "EmpresaIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_EmpresaIdEmpresa",
                table: "Municipio",
                column: "EmpresaIdEmpresa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Empresa");
        }
    }
}
