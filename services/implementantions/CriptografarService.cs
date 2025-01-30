using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using ZapAgenda_api_aspnet.services.interfaces;

namespace ZapAgenda_api_aspnet.services
{
    public class CriptografarService : ICriptografarService
    {
        public string HashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, 13);
        }

        public bool VerifySenha(string senha, string hashSenha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hashSenha);
        }
    }
}