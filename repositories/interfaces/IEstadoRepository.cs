using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IEstadoRepository
    {
        Task<List<Estado>?> GetAllAsync();
    }
}