using System.Net.Http.Headers;
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

            var municipios = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(municipios))
            {
                throw new ArgumentException("Municípios estão null ou vazios");
            }
            return JsonConvert.DeserializeObject<List<Municipio>>(municipios);
        }
        public async Task<List<Municipio>?> GetMunicipiosByNome(string NomeMunicipio)
        {
            var resposta = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{NomeMunicipio}");
            if(!resposta.IsSuccessStatusCode){
                throw new HttpRequestException($"Não existe município com o nome {NomeMunicipio}");
            }
            var municipios = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(municipios)){
                throw new ArgumentException("Municípios estão null ou vazios");
            }
            return JsonConvert.DeserializeObject<List<Municipio>>(municipios);
        }
        // todo: melhorar esse função que ela tá estupida, tá pegando todos municipios do estado e filtrando pra ver o certo pelo nome
        // Não consegui achar uma maneira de pegar todos com o mesmo nome e filtrar pela sigla sem ter que criar modelos novos de microregião etc
        public async Task<int> GetMunicipioId(string NomeMunicipio, string sigla)
        {
            var municipios = await GetMunicipiosBySigla(sigla) ?? throw new NullReferenceException();
            var municipioCorreto = municipios.FirstOrDefault(municipio => municipio.NomeMunicipio == NomeMunicipio) ?? throw new NullReferenceException();
            return municipioCorreto.IdMunicipio;
        }
    }
}