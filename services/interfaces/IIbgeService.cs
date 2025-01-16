using FluentResults;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.interfaces
{
    public interface IIbgeService
    {
        Task<Result<List<Estado>?>> GetAllEstados();
        Task<Result<List<Municipio>>> GetMunicipiosBySigla(string sigla);
        Task<Result<bool>> SeMunicipioExiste(string NomeMunicipio, string sigla);
        Task<List<Municipio>?> GetMunicipiosByNome(string NomeMunicipio);
    }
}