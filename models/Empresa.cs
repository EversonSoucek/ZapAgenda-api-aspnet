using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string NomeFantasia { get; set; }
        [Required]
        [MaxLength(14, ErrorMessage = "Cnpj deve receber apenas os números: 14 dígitos")]
        [Column(TypeName = "varchar(14)")]
        public required string Cnpj { get; set; }
        [MaxLength(255, ErrorMessage = "Razão Social não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        [Required]
        public required string RazaoSocial { get; set; }
        [MaxLength(50, ErrorMessage = "Tipo empresa não pode ser maior que 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public required string TipoEmpresa { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        [MaxLength(255, ErrorMessage = "Email não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20, ErrorMessage = "Telefone não pode ser maior que 20 caracteres")]
        [Column(TypeName = "varchar(20)")]
        public string Telefone {get;set;} = string.Empty;
    }
}