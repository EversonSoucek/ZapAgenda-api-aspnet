using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Agendamento;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("{IdEmpresa}/agendamento")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepo;
        public AgendamentoController(IAgendamentoRepository agendamentoRepo)
        {
            _agendamentoRepo = agendamentoRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAgendamentoDto createAgendamentoDto, Guid IdEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamento = await _agendamentoRepo.CreateAsync(createAgendamentoDto, IdEmpresa);
            if (agendamento.IsFailed)
            {
                return BadRequest(agendamento.Errors);
            }
            return Ok(agendamento);

        }
    }
}