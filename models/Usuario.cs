using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZapAgenda_api_aspnet.models
{
    [Table("Usuario")]
    public class Usuario : IdentityUser
    {
        [Key]
        public int IdEmpresa { get; set; }
        public DateTime UltimoLogin { get; set; }
        public DateTime UltimaModificacao {get;set;}
        public required string NomeInteiro {get;set;}
        public bool Status { get; set; }
    }
}