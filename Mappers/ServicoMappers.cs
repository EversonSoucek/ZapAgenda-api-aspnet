using ZapAgenda_api_aspnet.Dtos.Servico;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Mappers
{
    public static class ServicoMappers
    {
        public static Servico ToCreateServicoDto(this CreateServicoDto createServicoDto) {
            return new Servico {
                Descricao = createServicoDto.Descricao,
                Valor = createServicoDto.Valor,
                TempoDuracao = createServicoDto.TempoDuracao,
            };
        }
    }
}