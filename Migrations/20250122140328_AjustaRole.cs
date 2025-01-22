using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AjustaRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5beb1da9-824c-42c9-8cd1-5f7ff2b32913",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Max", "MAX" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5beb1da9-824c-42c9-8cd1-5f7ff2b32913",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "MaxAdmin", "MAXADMIN" });
        }
    }
}
