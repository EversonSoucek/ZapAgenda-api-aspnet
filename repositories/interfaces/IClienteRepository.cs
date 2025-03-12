using FluentResults;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Result<Cliente>> CreateAsync(Cliente cliente, Guid IdEmpresa);
    }
}