using FluentResults;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.services.implementantions;
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

        public async Task<Result<List<UsuarioDto>>> GetUsuariosByEmpresa(int IdEmpresa)
        {
            var usuarios = await _context.Usuario.Where(usuario => usuario.IdEmpresa == IdEmpresa).Select(s => s.ToUsuarioDto()).ToListAsync();
            if (usuarios.Count == 0) { return Result.Fail($"Não existe usuários na empresa de id{IdEmpresa}"); }

            return Result.Ok(usuarios);
        }

        public async Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa)
        {
            var usuariosResult = await _context.Usuario
                .Where(usuario => usuario.IdEmpresa == IdEmpresa)
                .ToListAsync();

            if (usuariosResult == null) { return Result.Fail($"Erro ao buscar usuários da empresa de id {IdEmpresa}"); }

            var nomeUsuarioRepetido = VerificaUsuarioDados.VerificaUsuario(usuariosResult, usuarioModel);
            if (nomeUsuarioRepetido.IsFailed) { return Result.Fail<Usuario>(nomeUsuarioRepetido.Errors); }

            var senhaAutorizada = VerificaUsuarioDados.VerificaSenha(usuarioModel.Senha);
            if (senhaAutorizada.IsFailed) { return Result.Fail(senhaAutorizada.Errors); }

            usuarioModel.IdEmpresa = IdEmpresa;
            usuarioModel.Senha = _criptService.HashSenha(usuarioModel.Senha);

            await _context.Usuario.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();

            return Result.Ok(usuarioModel);
        }

        public Task<Result<Usuario>> UpdateAsync(Usuario usuarioModel, int IdEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}