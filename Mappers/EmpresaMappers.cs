using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Mappers
{
    public static class EmpresaMappers
    {
        public static Empresa ToCreateEmpresaDto(this CreateEmpresaDto empresaDto) {
            return new Empresa {
                Cnpj = empresaDto.Cnpj,
                NomeFantasia = empresaDto.NomeFantasia,
                RazaoSocial = empresaDto.RazaoSocial,
                TipoEmpresa = empresaDto.TipoEmpresa,
                Email = empresaDto.Email,
                Telefone = empresaDto.Telefone
            };
        }

        public static Empresa ToUpdateEmpresaDto(this UpdateEmpresaDto empresaDto) {
            return new Empresa {
                Cnpj = empresaDto.Cnpj,
                NomeFantasia = empresaDto.NomeFantasia,
                RazaoSocial = empresaDto.RazaoSocial,
                TipoEmpresa = empresaDto.TipoEmpresa,
                Email = empresaDto.Email,
                Telefone = empresaDto.Telefone
            };
        }
    }
}