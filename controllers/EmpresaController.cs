using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("zapagenda/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepo;
        public EmpresaController(IEmpresaRepository empresaRepo)
        {
            _empresaRepo = empresaRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmpresaDto empresaDto)
        {
            var empresaModel = empresaDto.ToCreateEmpresaDto();
            await _empresaRepo.CreateAsync(empresaModel);
            return Ok();
        }
    }
}