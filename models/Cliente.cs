using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [MinLength(3)]
        [MaxLength(200, ErrorMessage = "Nome não pode ser maior que 200 caracteres")]
        [Column(TypeName = "varchar(200)")]
        public string? Nome { get; set; }
        [MaxLength(20, ErrorMessage = "Telefone não pode ser maior que 20 caracteres")]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = null!;
        [MinLength(11, ErrorMessage = "CPF precisa ter 11 digitos")]
        [MaxLength(11, ErrorMessage = "CPF não pode ter mais que 11 digitos")]
        [Column(TypeName = "varchar(11)")]
        public string Cpf { get; set; } = null!;
        public DateTime DataUltimoAgendamento { get; set; }
        [MaxLength(500, ErrorMessage = "Observação não pode ser maior que 500 caracteres")]
        [Column(TypeName = "varchar(500)")]
        public string? Observacao { get; set; }
        public int TotalAgendamentos { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateOnly? DataNascimento { get; set; }
        public bool Status { get; set; } = true;
        public Guid IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; } = null!;
    }
}