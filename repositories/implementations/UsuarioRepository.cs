using FluentResults;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CoreDBContext context) : base(context)
        {

        }

        public async Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa)
        {
            usuarioModel.IdEmpresa = IdEmpresa;
            await _context.Usuario.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }
    }
}