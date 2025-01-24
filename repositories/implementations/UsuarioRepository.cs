using FluentResults;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.services.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ICriptografarService _criptService;
        public UsuarioRepository(CoreDBContext context, ICriptografarService criptService) : base(context)
        {
            _criptService = criptService;
        }
        

        public async Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa)
        {
            usuarioModel.IdEmpresa = IdEmpresa;
            usuarioModel.Senha = _criptService.HashSenha(usuarioModel.Senha);
            await _context.Usuario.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }
    }
}