using Newtonsoft.Json;
using ZapAgenda_api_aspnet.interfaces;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.services
{
    public class IbgeService : IIbgeService
    {
        private readonly HttpClient _httpClient;

        public IbgeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Estado>?> GetAllEstados()
        {
            try
            {
                var resposta = await _httpClient.GetAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
                if(!resposta.IsSuccessStatusCode) {
                    throw new Exception($"Erro ao chamar api:{resposta.StatusCode}");
                }
                var estados = await resposta.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(estados)) { return null; }
                return JsonConvert.DeserializeObject<List<Estado>>(estados);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Municipio>?> GetMunicipiosBySigla(string sigla)
        {
            try
            {
                var resposta = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{sigla}/municipios");
                if(!resposta.IsSuccessStatusCode) {
                    throw new Exception($"Erro ao chamar api:{resposta.StatusCode}");
                }
                var municipios = await resposta.Content.ReadAsStringAsync();;
                if (string.IsNullOrEmpty(municipios)) { return null; }
                return JsonConvert.DeserializeObject<List<Municipio>>(municipios);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}