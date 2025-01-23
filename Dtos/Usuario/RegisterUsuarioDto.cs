using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.Dtos.Usuario
{
    public class RegisterUsuarioDto
    {
        public string? Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public required string Password { get; set; }
        [MinLength(3)]
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        public required string NomeInteiro { get; set; }
        [MaxLength(30, ErrorMessage = "Nome Fantasia não pode ser maior que 30 caracteres")]
        public required string Cargo { get; set; }
    }
}