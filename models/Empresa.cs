using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public required string NomeFantasia { get; set; }
        [MaxLength(14)]
        [Column(TypeName = "varchar(14)")]
        public required string Cnpj { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public required string RazaoSocial { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public required string TipoEmpresa { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Telefone {get;set;} = string.Empty;
    }
}