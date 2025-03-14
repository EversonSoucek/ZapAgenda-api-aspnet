using FluentResults;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly CoreDBContext _context;
        public ServicoRepository(CoreDBContext context)
        {
            _context = context;
        }

        public async Task<Result<Servico>> CreateAsync(Servico servico, Guid IdEmpresa)
        {
            servico.IdEmpresa = IdEmpresa;
            await _context.AddAsync(servico);
            await _context.SaveChangesAsync();
            return Result.Ok(servico);
        }
    }
}