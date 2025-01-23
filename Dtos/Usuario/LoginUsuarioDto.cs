using System.ComponentModel.DataAnnotations;

namespace ZapAgenda_api_aspnet.Dtos.Usuario
{
    public class LoginUsuarioDto
    {
        public string? Username { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? Login { get; set; }
    }
}