using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZapAgenda_api_aspnet.models;

namespace ZapAgenda_api_aspnet.Dtos.Empresa
{
    public class UpdateEmpresaDto
    {
        [MaxLength(255, ErrorMessage = "Nome Fantasia não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string NomeFantasia { get; set; }
        [MaxLength(14, ErrorMessage = "Cnpj deve receber apenas os números: 14 dígitos")]
        [Column(TypeName = "varchar(14)")]
        public required string Cnpj { get; set; }
        [MaxLength(255, ErrorMessage = "Razão Social não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public required string RazaoSocial { get; set; }
        [MaxLength(50, ErrorMessage = "Tipo empresa não pode ser maior que 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public required string TipoEmpresa { get; set; }
        [MaxLength(255, ErrorMessage = "Email não pode ser maior que 255 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20, ErrorMessage = "Telefone não pode ser maior que 20 caracteres")]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;
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
        [MaxLength(255, ErrorMessage = "Nome do município naõ pode ser maior que 255")]
        public string NomeMunicipio { get; set; } = null!;
    }
}