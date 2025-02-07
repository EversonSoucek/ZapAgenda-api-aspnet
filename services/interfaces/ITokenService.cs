using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.services.interfaces
{
    public interface ITokenService
    {
        string CreateToken(UsuarioDto usuario);
    }
}