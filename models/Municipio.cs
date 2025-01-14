using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapAgenda_api_aspnet.models
{
    [NotMapped]
    public class Municipio
    {
        [Key]
        public required int IdMunicipio { get; set; }        
        public required string Nome { get; set; }
    }
}