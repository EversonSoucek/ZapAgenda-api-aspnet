using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.interfaces
{
    public interface IIbgeService
    {
        Task<List<Estado>?> GetAllEstados();
        Task <List<Municipio>?> GetMunicipiosBySigla(string sigla);
    }
}