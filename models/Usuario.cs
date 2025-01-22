using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Usuario")]
    public class Usuario : IdentityUser
    {
        public int IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa {get; set;} = null!;
        public DateTime UltimoLogin { get; set; }
        public DateTime UltimaModificacao {get;set;}
        [MinLength(3)]
        public required string NomeInteiro {get;set;}
        public bool Status { get; set; } = true;
    }
}