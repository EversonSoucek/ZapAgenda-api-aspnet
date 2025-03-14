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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateServicoDto createServicoDto, Guid IdEmpresa)
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
            return Ok(result);
        }
    }
}