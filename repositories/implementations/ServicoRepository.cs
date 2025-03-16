using FluentResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<Servico>> GetById(int IdServico, Guid IdEmpresa)
        {
            var servico = await _context.Servico.FirstOrDefaultAsync(servico => servico.IdServico == IdServico);
            if (servico == null)
            {
                return Result.Fail($"Não existe Serviço com id:{IdServico}");
            }
            if (servico.IdEmpresa != IdEmpresa)
            {
                return Result.Fail($"Serviço não pertence a empresa");
            }
            return Result.Ok(servico);
        }
    }
}