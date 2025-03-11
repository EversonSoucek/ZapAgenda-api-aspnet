using Microsoft.AspNetCore.Authorization;
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
        public ClienteController(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto createClienteDto,Guid IdEmpresa)
        {
            var cliente = createClienteDto.ToCreateClienteDto();
            var result = await _clienteRepo.CreateAsync(cliente, IdEmpresa);
            if(result.IsFailed) {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}