using System.ComponentModel.DataAnnotations;

namespace ZapAgenda_api_aspnet.Dtos.Usuario
{
    public class RegisterUsuarioDto
    { 
        public required string Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public required string Password { get; set; }
        public required string NomeInteiro {get;set;}
        public required string Cargo { get; set; }
    }
}