using System.ComponentModel.DataAnnotations;

namespace ZapAgenda_api_aspnet.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        [MinLength(4)]
        [MaxLength(50, ErrorMessage ="Nome de usuário não pode ser maior que 50 caracteres")]
        public required string NomeUsuario { get; set; }
        [MinLength(3)]
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        public required string NomeInteiro {get;set;}
        [MinLength(8)]
        public  required string Senha { get; set; }
        [EmailAddress]
        [MaxLength(255,ErrorMessage ="Email não pode ser maior que 255 caracteres")]
        public string? Email { get; set; }
        public int IdCargo { get; set; }
    }
}