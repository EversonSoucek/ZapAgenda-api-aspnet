using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Cliente;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("{IdEmpresa}/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IEmpresaRepository _empresaRepo;
        public ClienteController(IClienteRepository clienteRepo, IEmpresaRepository empresaRepo)
        {
            _clienteRepo = clienteRepo;
            _empresaRepo = empresaRepo;
        }


        [HttpGet("{idCliente}:int")]
        public async Task<IActionResult> GetById([FromRoute] int idCliente, Guid IdEmpresa)
        {

            if (await _empresaRepo.GetByGuidAsync(IdEmpresa) == null)
            {
                return NotFound($"Não existe empresa com ID {IdEmpresa}.");
            }
            if(idCliente == 0) {
                return BadRequest("id é 0");
            }
            var cliente = await _clienteRepo.GetByIdAsync(idCliente);
            if (cliente.IsFailed)
            {
                return BadRequest("Cliente não pertence a empresa");
            }
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto createClienteDto, Guid IdEmpresa)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var cliente = createClienteDto.ToCreateClienteDto();
            var result = await _clienteRepo.CreateAsync(cliente, IdEmpresa);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtAction(nameof(GetById), new { idCliente = cliente.IdCliente, IdEmpresa = IdEmpresa }, cliente);
        }
    }
}