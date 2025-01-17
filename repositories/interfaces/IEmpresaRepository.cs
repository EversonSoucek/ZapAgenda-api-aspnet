using FluentResults;
using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Result<Empresa>> UpdateAsync ( UpdateEmpresaDto empresaDto, int id);
        new Task<Empresa> CreateAsync (Empresa empresaModel);
    }
}