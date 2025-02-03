using FluentResults;

namespace ZapAgenda_api_aspnet.helpers
{
    public class VerificaEmpresa
    {
        public static Result<bool> PertenceEmpresa(int id, int IdEmpresa)
        {
            if (id != IdEmpresa)
            {
                return Result.Fail($"Não pertence a empresa de id:{IdEmpresa}");
            }
            return Result.Ok(true);
        }
    }
}