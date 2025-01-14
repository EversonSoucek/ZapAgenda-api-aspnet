using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AjustaTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Estado_EstadoUf",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Municipio_MunicipioId",
                table: "Empresa");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_EstadoUf",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_MunicipioId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EstadoUf",
                table: "Empresa");

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Empresa",
                type: "varchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Empresa",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldMaxLength: 3)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EstadoUf",
                table: "Empresa",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Uf = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Uf);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    IdMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.IdMunicipio);
                })
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
    }
}
