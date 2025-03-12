using FluentResults;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Mappers;
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
        public async Task<List<Cliente>> GetAllAsync(int IdCliente, Guid IdEmpresa)
        {
            return await _context.Cliente.Select(cliente => cliente.ToClienteDto()).ToListAsync();
        }
        public async Task<Result<Cliente>> CreateAsync(Cliente cliente, Guid IdEmpresa)
        {
            var IsCpf = VerificaDados.VerificaCpf(cliente.Cpf);
            if (IsCpf.IsFailed)
            {
                return Result.Fail(IsCpf.Errors);
            }

            var clientes = await GetAllAsync();
            if (clientes.FirstOrDefault(cliente => cliente.Cpf == cliente.Cpf) != null)
            {
                return Result.Fail("Já existe Cliente com o mesmo cpf");
            }
            cliente.IdEmpresa = IdEmpresa;

            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return Result.Ok(cliente);
        }


    }
}