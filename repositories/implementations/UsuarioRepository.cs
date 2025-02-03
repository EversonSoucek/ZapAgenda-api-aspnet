using FluentResults;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.helpers;
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

            if (!string.IsNullOrEmpty(usuarioModel.Cpf))
            {
                var IsCpf = VerificaUsuarioDados.VerificaCpf(usuarioModel.Cpf);
                if (!IsCpf.IsSuccess)
                {
                    return Result.Fail(IsCpf.Errors);
                }
            }

            usuarioModel.IdEmpresa = IdEmpresa;
            usuarioModel.Senha = _criptService.HashSenha(usuarioModel.Senha);

            await _context.Usuario.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();

            return Result.Ok(usuarioModel);
        }

        public async Task<Result<Usuario>> UpdateAsync(UpdateUsuarioDto updateUsuarioDto, int IdUsuario, int IdEmpresa)
        {
            var usuarioModel = await _context.Usuario.FindAsync(IdUsuario);

            if (usuarioModel == null)
            {
                return Result.Fail<Usuario>("Usuário não encontrado.");
            }

            if (usuarioModel.IdEmpresa != IdEmpresa)
            {
                return Result.Fail("Usuário não pertence a empresa");
            }

            if (updateUsuarioDto.IdCargo == null || updateUsuarioDto.IdCargo != 0)
            {
                if (!ValidaCargo.ValidaIdCargo(updateUsuarioDto.IdCargo).IsSuccess)
                {
                    return Result.Fail("Cargo não existe");
                }
                usuarioModel.IdCargo = updateUsuarioDto.IdCargo;
            }

            if (!string.IsNullOrEmpty(updateUsuarioDto.Cpf))
            {
                if (!VerificaUsuarioDados.VerificaCpf(updateUsuarioDto.Cpf).IsSuccess)
                {
                    return Result.Fail(VerificaUsuarioDados.VerificaCpf(updateUsuarioDto.Cpf).Errors);
                }
                usuarioModel.Cpf = updateUsuarioDto.Cpf;
            }

            usuarioModel.NomeUsuario = updateUsuarioDto.NomeUsuario ?? usuarioModel.NomeUsuario;
            usuarioModel.NomeInteiro = updateUsuarioDto.NomeInteiro ?? usuarioModel.NomeInteiro;
            usuarioModel.Email = updateUsuarioDto.Email ?? usuarioModel.Email;
            usuarioModel.UltimaModificacao = DateTime.Now;
            _context.Usuario.Update(usuarioModel);
            await _context.SaveChangesAsync();

            return Result.Ok(usuarioModel);
        }

    }
}