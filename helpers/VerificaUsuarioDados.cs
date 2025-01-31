using FluentResults;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.services.implementantions
{
    public static class VerificaUsuarioDados
    {
        public static Result<bool> VerificaUsuario(List<Usuario> usuariosEmpresa, Usuario usuarioModel)
        {

            var nomeUsuarioIgual = usuariosEmpresa.FirstOrDefault(usuario => usuario.NomeUsuario == usuarioModel.NomeUsuario);
            if (nomeUsuarioIgual != null)
            {
                return Result.Fail("Não pode ter usuários com o mesmo nome de usuário.");
            }
            return Result.Ok(true);
        }

        public static Result<bool> VerificaSenha(string senha)
        {
            if (senha.Length < 8)
            {
                return Result.Fail("Senha não pode ser menor que 8 caracteres");
            }
            if (!senha.Any(char.IsUpper))
            {
                return Result.Fail("Senha precisa ter 1 caracter em maiúsculo");
            }
            if (!senha.Any(char.IsLetter))
            {
                return Result.Fail("Senha precisa ter letras");
            }
            if (!senha.Any(char.IsDigit))
            {
                return Result.Fail("Senha precisa ter digitos");
            }
            return Result.Ok(true);
        }
    }
}