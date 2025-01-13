using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class EmpresaRepository :Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(CoreDBContext context) : base(context)
        {
        }

    }
}