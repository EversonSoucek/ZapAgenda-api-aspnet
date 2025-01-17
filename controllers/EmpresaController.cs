using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.Exceptions;
using ZapAgenda_api_aspnet.Mappers;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresa = await _empresaRepo.GetAllAsync();
            return Ok(empresa);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var empresa = await _empresaRepo.GetByIdAsync(id);
            if (empresa == null)
            {
                throw new CustomBadRequest(
                    title: "Não existe a empresa",
                    detail: $"Não existe empresa de código: {id}"
                );
            }
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmpresaDto empresaDto)
        {
            var empresaModel = empresaDto.ToCreateEmpresaDto();
            await _empresaRepo.CreateAsync(empresaModel);
            return CreatedAtAction(nameof(GetById), new { id = empresaModel.IdEmpresa }, empresaModel);
        }

        [HttpDelete("{id}:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var empresa = await _empresaRepo.DeleteAsync(id);
            if (empresa == null)
            {
                throw new CustomBadRequest(
                    title: "Não existe a empresa",
                    detail: $"Não existe empresa de código: {id}"
                );
            }
            // todo: Pesquisar os códigos corretos para cada tipo de requisição
            return StatusCode(204);
        }

        [HttpPut("{id}:int")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmpresaDto empresaDto) {
            var empresa = await _empresaRepo.UpdateAsync(empresaDto, id ) ?? throw new NullReferenceException($"empresa está nulo ");
            return Ok(empresa.Value);
        }
    }
}