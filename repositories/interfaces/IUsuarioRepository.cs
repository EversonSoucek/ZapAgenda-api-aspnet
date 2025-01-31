using FluentResults;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa);
        Task<Result<List<UsuarioDto>>> GetUsuariosByEmpresa(int IdEmpresa);
        Task<Result<Usuario>> UpdateAsync(Usuario usuarioModel, int IdEmpresa);
    }
}