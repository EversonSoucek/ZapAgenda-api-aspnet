using ZapAgenda_api_aspnet.Dtos.Agendamento;
using ZapAgenda_api_aspnet.Dtos.AgendamentoServico;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Mappers
{
    public static class AgendamentoMappers
    {
        public static Agendamento ToCreateAgendamentoDto(this CreateAgendamentoDto createAgendamentoDto)
        {
            return new Agendamento
            {
                DataHoraInicio = createAgendamentoDto.DataHoraInicio,
                IdCliente = createAgendamentoDto.IdCliente,
                IdUsuario = createAgendamentoDto.IdUsuario,
                Observacao = createAgendamentoDto.Observacao,
            };
        }

        public static AgendamentoDto ToAgendamentoDto(this Agendamento agendamento)
        {
            return new AgendamentoDto
            {
                DataHoraFim = agendamento.DataHoraFim,
                DataHoraInicio = agendamento.DataHoraInicio,
                IdAgendamento = agendamento.Id,
                IdCliente = agendamento.IdCliente,
                IdUsuario = agendamento.IdUsuario,
                Observacao = agendamento.Observacao,
                StatusAgendamento = agendamento.StatusAgendamento,
                TempoDuracaoAgendamento = agendamento.TempoDuracaoAgendamento,
                ValorTotal = agendamento.ValorTotal,
                Cliente = agendamento.Cliente.ToClienteDto(),
                // Usuario = agendamento.Usuario.ToUsuarioDto(),

                // Mapeia apenas para o DTO simplificado, evitando loop infinito
                AgendamentoServico = agendamento.AgendamentoServico
    .Select(s => new AgendamentoServicoDto
    {
        IdAgendamento = s.IdAgendamento,
        IdServico = s.IdServico,
        Servico = s.Servico?.ToServicoDto()  // ? garante que não quebre se Servico for nulo
    })
    .ToList()

            };
        }
    }
}