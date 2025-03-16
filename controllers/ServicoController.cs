using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Servico;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("{IdEmpresa}/servico")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _servicoRepo;
        public ServicoController(IServicoRepository servicoRepo)
        {
            _servicoRepo = servicoRepo;
        }

        [HttpGet("{IdServico}:int")]
        public async Task<IActionResult> GetById([FromRoute] int IdServico, Guid IdEmpresa)
        {
            var servico = await _servicoRepo.GetById(IdServico, IdEmpresa);
            if (servico.IsFailed)
            {
                return BadRequest(servico.Errors);
            }
            return Ok(servico.Value);
        }

        //ver pq não retorna o objeto da empresa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServicoDto createServicoDto, Guid IdEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var servico = createServicoDto.ToCreateServicoDto();
            var result = await _servicoRepo.CreateAsync(servico, IdEmpresa);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtAction(nameof(GetById), new{idServico = servico.IdServico,IdEmpresa = IdEmpresa},servico);
        }
    }
}