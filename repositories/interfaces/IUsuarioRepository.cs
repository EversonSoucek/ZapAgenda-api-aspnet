using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;

namespace ZapAgenda_api_aspnet.repositories.interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        new Task<Result<Usuario>> CreateAsync(Usuario usuarioModel, int IdEmpresa);
    }
}