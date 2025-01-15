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
            var resposta = await _httpClient.GetAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            if (!resposta.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Erro ao chamar api:{resposta.StatusCode}");
            }
            var estados = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(estados))
            {
                throw new ArgumentException("Estados estão null ou vazios");
            }
            return JsonConvert.DeserializeObject<List<Estado>>(estados);
        }

        public async Task<List<Municipio>?> GetMunicipiosBySigla(string sigla)
        {
            var resposta = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{sigla}/municipios");
            if (!resposta.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Erro ao chamar api:{resposta.StatusCode}");
            }

            var municipios = await resposta.Content.ReadAsStringAsync(); ;
            if (string.IsNullOrEmpty(municipios))
            {
                throw new ArgumentException("Municipios estão null ou vazios");
            }
            return JsonConvert.DeserializeObject<List<Municipio>>(municipios);
        }
        public async Task<string> GetMunicipioId(string NomeMunicipio, string sigla)
        {
            var municipios = await GetMunicipiosBySigla(sigla) ?? throw new NullReferenceException("Sigla Não existe");
            var municipioCorreto = municipios.FirstOrDefault(cidade => cidade.NomeMunicipio == NomeMunicipio) ?? throw new NullReferenceException("Não existe municipio");
            return municipioCorreto.NomeMunicipio;
        }
    }
}