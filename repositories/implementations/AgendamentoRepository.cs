using FluentResults;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEmpresaRepository _empresaRepo;
        public AgendamentoRepository(CoreDBContext context, IEmpresaRepository empresaRepo)
        {
            _context = context;
            _empresaRepo = empresaRepo;
        }

        public async Task<Result<List<Agendamento>>> GetAllByEmpresa(Guid IdEmpresa)
        {
            var empresa = await _empresaRepo.GetById(IdEmpresa);
            if (empresa.IsFailed)
            {
                return Result.Fail($"Não existe empresa de id{IdEmpresa}");
            }
            return Result.Ok(await _context.Agendamento.Where(agen => agen.IdEmpresa == IdEmpresa).ToListAsync());
        }

        public async Task<Result<Agendamento>> GetById(int IdAgendamento, Guid IdEmpresa)
        {
            var agendamento = await _context.Agendamento.FindAsync(IdAgendamento);
            if (agendamento == null)
            {
                return Result.Fail($"Não existe agendamento de id:{IdAgendamento}");
            }
            if (agendamento.IdEmpresa != IdEmpresa)
            {
                return Result.Fail($"Agendamento não pertence a empresa");
            }
            return Result.Ok(agendamento);
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
        //todo: Adiciona validações está cru
        public async Task<Result<Agendamento>> UpdateAsync(UpdateAgendamentoDto updateAgendamentoDto, int IdAgendamento, Guid IdEmpresa)
        {
            var agendamento = await GetById(IdAgendamento, IdEmpresa);
            if (agendamento.IsFailed)
            {
                return Result.Fail(agendamento.Errors);
            }
            var agendamentoValor = agendamento.Value;
            agendamentoValor.IdCliente = updateAgendamentoDto.IdCliente;
            agendamentoValor.IdUsuario = updateAgendamentoDto.IdUsuario;
            agendamentoValor.Observacao = updateAgendamentoDto.Observacao;
            agendamentoValor.StatusAgendamento = updateAgendamentoDto.StatusAgendamento;
            agendamentoValor.ValorTotal = updateAgendamentoDto.ValorTotal;

            var agendamentosServicosRemover = await _context.AgendamentoServico.Where(x => x.IdAgendamento == IdAgendamento).ToListAsync();

            _context.AgendamentoServico.RemoveRange(agendamentosServicosRemover);

            var agendamentosServicosAdicionar = updateAgendamentoDto.IdServico.Select(idServico => new AgendamentoServico
            {
                IdAgendamento = IdAgendamento,
                IdServico = idServico
            }).ToList();

            await _context.AgendamentoServico.AddRangeAsync(agendamentosServicosAdicionar);
            await _context.SaveChangesAsync();
            return Result.Ok(agendamentoValor);
        }
    }
}