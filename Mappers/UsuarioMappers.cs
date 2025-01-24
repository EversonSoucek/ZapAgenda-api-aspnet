using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Mappers
{
    public static class UsuarioMappers
    {
        public static Usuario ToCreateUsuarioDto(this CreateUsuarioDto createUsuarioDto, int IdEmpresa)
        {
            return new Usuario
            {
                NomeInteiro = createUsuarioDto.NomeInteiro,
                Senha = createUsuarioDto.Senha,
                Email = createUsuarioDto.Email,
                IdEmpresa = IdEmpresa,
                NomeUsuario = createUsuarioDto.NomeUsuario,
                IdCargo = createUsuarioDto.IdCargo
            };
        }
    }
}