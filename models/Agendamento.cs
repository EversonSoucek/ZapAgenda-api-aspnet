using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public int IdAgendamento { get; set; }
        [MaxLength(50, ErrorMessage = "Status não pode ser maior que 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public string StatusAgendamento { get; set; } = null!;
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        [MaxLength(500, ErrorMessage = "Observação não pode ser maior que 500 caracteres")]
        [Column(TypeName = "varchar(500)")]
        public string Observacao { get; set; } = null!;
        public List<AgendamentoServico> AgendamentoServico { get; set; } = [];
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = null!;
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } = null!;
        public Guid IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; } = null!;
    }
}