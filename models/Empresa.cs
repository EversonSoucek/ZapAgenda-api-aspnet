using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public Guid IdEmpresa { get; set; } = Guid.NewGuid();
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
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;
        [MaxLength(255, ErrorMessage = "Email não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20, ErrorMessage = "Telefone não pode ser maior que 20 caracteres")]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;
        [MaxLength(8, ErrorMessage = "Cep não pode ter mais que 8 caracteres, não deve ter pontos ou traços")]
        [Column(TypeName = "varchar(8)")]
        public required string Cep { get; set; }
        [MaxLength(255, ErrorMessage = "Logradouro não pode ter mais que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string Logradouro { get; set; }
        [MaxLength(100, ErrorMessage = "Logradouro não pode ter mais que 100 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string? Numero { get; set; }
        [MaxLength(255, ErrorMessage = "complemento não pode ter mais que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string? Complemento { get; set; }
        [Column(TypeName = "varchar(3)")]
        [MaxLength(3, ErrorMessage = "Não pode ser maior que 3")]
        public string Sigla { get; set; } = null!;
        [Column(TypeName = "varchar(255)")]
        [MaxLength(255, ErrorMessage = "Nome do município não pode ser maior que 255 caracteres")]
        public string NomeMunicipio { get; set; } = null!;
        public List<Usuario> Usuario { get; set; } = [];
        public List<Servico> Servico { get; set; } = [];
        public List<Cliente> Cliente { get; set; } = [];
    }
}