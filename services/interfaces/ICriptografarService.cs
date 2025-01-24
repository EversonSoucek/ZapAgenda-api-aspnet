using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZapAgenda_api_aspnet.services.interfaces
{
    public interface ICriptografarService
    {
        string HashSenha(string senha);
        bool VerifySenha(string senha, string hashSenha);
    }
}