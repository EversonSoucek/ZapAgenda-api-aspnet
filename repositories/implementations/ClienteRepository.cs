using FluentResults;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.services.implementantions;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CoreDBContext context) : base(context)
        {

        }
        public new async Task<Result<Cliente>> CreateAsync(Cliente cliente,Guid IdEmpresa)
        {
            var IsCpf = VerificaDados.VerificaCpf(cliente.Cpf);
            if (IsCpf.IsFailed)
            {
                return Result.Fail(IsCpf.Errors);
            }
            cliente.IdEmpresa = IdEmpresa;

            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return Result.Ok(cliente);
        }
    }
}