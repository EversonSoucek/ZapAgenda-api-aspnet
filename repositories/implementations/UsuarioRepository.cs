using FluentResults;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.services.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ICriptografarService _criptService;
        private readonly IEmpresaRepository _empresaRepo;
        public UsuarioRepository(CoreDBContext context, ICriptografarService criptService, IEmpresaRepository empresaRepo) : base(context)
        {
            _criptService = criptService;
            _empresaRepo = empresaRepo;
        }


        public async Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa)
        {
            usuarioModel.IdEmpresa = IdEmpresa;
            usuarioModel.Senha = _criptService.HashSenha(usuarioModel.Senha);
            await _context.Usuario.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<Result<List<UsuarioDto>>> GetUsuarioByEmpresa(int IdEmpresa)
        {
            var usuarios = await _context.Usuario.Where(usuario => usuario.IdEmpresa == IdEmpresa).Select(s => s.ToUsuarioDto()).ToListAsync();
            if (usuarios.Count == 0) {
                return Result.Fail($"Não existe usuários na empresa de id{IdEmpresa}");
            }
            return Result.Ok(usuarios);
        }
    }
}