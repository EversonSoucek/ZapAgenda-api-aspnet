using FluentResults;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Agendamento;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly CoreDBContext _context;
        public AgendamentoRepository(CoreDBContext context)
        {
            _context = context;
        }
        public async Task<Result<Agendamento>> CreateAsync(CreateAgendamentoDto createAgendamentoDto, Guid IdEmpresa)
        {
            var agendamento = createAgendamentoDto.ToCreateAgendamentoDto();
            agendamento.IdEmpresa = IdEmpresa;
            agendamento.DataHoraFim = DateTime.Parse("10:00");
            agendamento.ValorTotal = 10;
            agendamento.TempoDuracaoAgendamento = TimeSpan.FromHours(1);
            await _context.Agendamento.AddAsync(agendamento);
            await _context.SaveChangesAsync();

            var agendamentoServicos = createAgendamentoDto.IdServico.Select(idServico => new AgendamentoServico
            {
                IdAgendamento = agendamento.IdAgendamento,
                IdServico = idServico,
            }).ToList();

            await _context.AgendamentoServico.AddRangeAsync(agendamentoServicos);
            await _context.SaveChangesAsync();
            return Result.Ok(agendamento);
        }
    }
}