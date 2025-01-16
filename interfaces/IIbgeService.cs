using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.interfaces
{
    public interface IIbgeService
    {
        Task<List<Estado>?> GetAllEstados();
        Task<List<Municipio>?> GetMunicipiosBySigla(string sigla);
        Task<int> GetMunicipioId(string NomeMunicipio, string sigla);
        Task<List<Municipio>?> GetMunicipiosByNome(string NomeMunicipio);
    }
}