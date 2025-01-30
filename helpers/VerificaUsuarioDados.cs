using FluentResults;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.services.interfaces;

namespace ZapAgenda_api_aspnet.services.implementantions
{
    public static class VerificaUsuarioDados
{
    public static Result<bool> VerificaUsuario(List<Usuario> usuariosEmpresa, string nomeNovoUsuario)
    {
        var usuarioIgual = usuariosEmpresa.FirstOrDefault(usuario => usuario.NomeUsuario == nomeNovoUsuario);
        if (usuarioIgual != null)
        {
            return Result.Fail("Não pode ter usuários com o mesmo nome de usuário.");
        }
        return Result.Ok(true);
    }
}

}