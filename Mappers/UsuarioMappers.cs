using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Mappers
{
    public static class UsuarioMappers
    {
        public static Usuario ToCreateUsuario (this RegisterUsuarioDto registerUsuarioDto, int IdEmpresa) {
            return new Usuario {
                NomeInteiro = registerUsuarioDto.NomeInteiro,
                UserName = registerUsuarioDto.Username,
                Email = registerUsuarioDto.Email,
                IdEmpresa = IdEmpresa
            };
        }
    }
}