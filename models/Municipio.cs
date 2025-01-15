using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ZapAgenda_api_aspnet.models
{
    [NotMapped]
    public class Municipio
    {
        [Key]
        [JsonPropertyName("id")]
        public required int IdMunicipio { get; set; }
        [JsonPropertyName("nome")]
        public required string Nome { get; set; }
    }
}