using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("zapagenda/{IdEmpresa}/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmpresaRepository _empresarepo;

        public UsuarioController(UserManager<Usuario> userManager, IEmpresaRepository empresaRepo)
        {
            _userManager = userManager;
            _empresarepo = empresaRepo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUsuarioDto registerUsuarioDto, int IdEmpresa)
        {
            var empresa = await _empresarepo.GetByIdAsync(IdEmpresa);
            if(empresa.IsFailed) {
                return BadRequest($"Não existe empresa de id: {IdEmpresa}");
            }
            var usuario = registerUsuarioDto.ToCreateUsuario(IdEmpresa);
            var result = await _userManager.CreateAsync(usuario, registerUsuarioDto.Password);
            if (result.Succeeded)
            {
                return Ok($"Usuário criado com sucesso para a empresa {IdEmpresa}");
            }
            return BadRequest(result.Errors);
        }
    }
}