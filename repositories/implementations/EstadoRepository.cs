using Newtonsoft.Json;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class EstadoRepository : IEstadoRepository
    {
        public async Task<List<Estado>?> GetAllAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            if(response == null) {
                return null;
            }
            return JsonConvert.DeserializeObject<List<Estado>>(response);
        }
    }
}