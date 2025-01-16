using System.Net.Http.Headers;
using FluentResults;
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
        public async Task<Result<List<Estado>?>> GetAllEstados()
        {
            var resposta = await _httpClient.GetAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
            if (!resposta.IsSuccessStatusCode)
            {
                return Result.Fail($"Não foi possível se comunicar com a api statusCode:{resposta.StatusCode}");
            }
            var estados = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(estados))
            {
                return Result.Fail($"estados está vazio ou nulo");
            }
            var estadosDeserializados = JsonConvert.DeserializeObject<List<Estado>>(estados);
            if (estadosDeserializados.Count == 0)
            {
                return Result.Fail($"Array de estados está vazia");
            }
            return estadosDeserializados;
        }

        public async Task<Result<List<Municipio>>> GetMunicipiosBySigla(string sigla)
        {
            var resposta = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{sigla}/municipios");
            if (!resposta.IsSuccessStatusCode)
            {
                return Result.Fail($"Não foi possível se comunicar com a api statusCode:{resposta.StatusCode}");
            }

            var municipios = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(municipios))
            {
                return Result.Fail($"Null ou Vazio:Não existe estado com a sigla: {sigla}");
            }
            var municipiosDeserializados = JsonConvert.DeserializeObject<List<Municipio>>(municipios);

            if (municipiosDeserializados == null)
            {
                return Result.Fail($"Erro ao deserializar municípios para a sigla: {sigla}");
            }

            if (municipiosDeserializados.Count == 0)
            {
                return Result.Fail($"Lista vazia:Não existem múnicipios para a sigla: {sigla}");
            }
            return Result.Ok(municipiosDeserializados);
        }
        public async Task<List<Municipio>?> GetMunicipiosByNome(string NomeMunicipio)
        {
            var resposta = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{NomeMunicipio}");
            if (!resposta.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Não existe município com o nome {NomeMunicipio}");
            }
            var municipios = await resposta.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(municipios))
            {
                throw new ArgumentException("Municípios estão null ou vazios");
            }
            return JsonConvert.DeserializeObject<List<Municipio>>(municipios);
        }

        // todo: melhorar esse função que ela tá estupida, tá pegando todos municipios do estado e filtrando pra ver o certo pelo nome
        // Não consegui achar uma maneira de pegar todos com o mesmo nome e filtrar pela sigla sem ter que criar modelos novos de microregião etc
        public async Task<Result<bool>> SeMunicipioExiste(string NomeMunicipio, string sigla)
        {
            var municipios = await GetMunicipiosBySigla(sigla);
            if (municipios.IsFailed)
            {
                return Result.Fail(municipios.Errors);
            }
            var municipioCorreto = municipios.Value.FirstOrDefault(municipio => municipio.NomeMunicipio == NomeMunicipio);
            if (municipioCorreto == null)
            {
                return Result.Fail($"Não foi encontrado o município {NomeMunicipio} pro estado de sigla: {sigla}");
            }
            return Result.Ok();
        }
    }
}