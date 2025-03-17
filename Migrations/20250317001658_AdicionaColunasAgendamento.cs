using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunasAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoDuracaoAgendamento",
                table: "AgendamentoServico");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "AgendamentoServico");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Servico",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDuracaoAgendamento",
                table: "Agendamento",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Agendamento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoDuracaoAgendamento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Agendamento");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Servico",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDuracaoAgendamento",
                table: "AgendamentoServico",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<float>(
                name: "ValorTotal",
                table: "AgendamentoServico",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
