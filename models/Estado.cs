using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [NotMapped]
    public class Estado
    {
        [Key]
        public required string Uf { get; set; }
        public required string Nome { get; set; }
    }
}