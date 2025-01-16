using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AjustaColunasMunicipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMunicipio",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "NomeMunicipio",
                table: "Empresa",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeMunicipio",
                table: "Empresa");

            migrationBuilder.AddColumn<int>(
                name: "IdMunicipio",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
