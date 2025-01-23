using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa {get; set;} = null!;
        public DateTime UltimoLogin { get; set; }
        public DateTime UltimaModificacao {get;set;}
        [MinLength(3)]
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string NomeInteiro {get;set;}
        public bool Status { get; set; } = true;
        public string? Login {get;set;}
    }
}