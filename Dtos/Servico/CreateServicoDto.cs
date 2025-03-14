using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZapAgenda_api_aspnet.Dtos.Servico
{
    public class CreateServicoDto
    {
        public string Descricao { get; set; } = null!;
        public float Valor { get; set; }
        public TimeSpan TempoDuracao { get; set; }
    }
}