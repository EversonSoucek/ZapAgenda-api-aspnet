using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZapAgenda_api_aspnet.models
{
    [NotMapped]
    public class Estado
    {
        [Key]
        [JsonPropertyName("sigla")]
        public required string Sigla { get; set; }
        [JsonPropertyName("nome")]
        public required string Nome { get; set; }
    }
}