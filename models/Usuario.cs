using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [MinLength(4)]
        [MaxLength(50, ErrorMessage = "Nome de usuário não pode ser maior que 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public required string NomeUsuario { get; set; }
        public int IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; } = null!;
        public DateTime UltimoLogin { get; set; } = DateTime.Now;
        public DateTime UltimaModificacao { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        [MinLength(3)]
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string NomeInteiro { get; set; }
        public bool Status { get; set; } = true;
        [MinLength(8)]
        [MaxLength(50, ErrorMessage = "Senha não pode ser maior que 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public required string Senha { get; set; }
        [EmailAddress]
        [MaxLength(255, ErrorMessage = "Email não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }
        public int TentativasLogin { get; set; }
        public DateTime UltimaTentativaFalhaLogin { get; set; } = DateTime.MinValue;
        public bool PerfilBloqueado { get; set; } = false;
        public required int IdCargo { get; set; }
        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; } = null!;
    }
}