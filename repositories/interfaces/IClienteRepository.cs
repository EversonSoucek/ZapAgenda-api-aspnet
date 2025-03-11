using FluentResults;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IClienteRepository
    {
        Task<Result<Cliente>> CreateAsync(Cliente cliente,Guid IdEmpresa);
    }
}