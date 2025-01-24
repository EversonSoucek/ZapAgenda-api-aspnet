using Microsoft.AspNetCore.Mvc;
using ZapAgenda_api_aspnet.Dtos.Usuario;
using ZapAgenda_api_aspnet.Mappers;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.controllers
{
    [Route("Zapagenda/{IdEmpresa}/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEmpresaRepository _empresaRepo;
        public UsuarioController(IUsuarioRepository usuariorepo, IEmpresaRepository empresaRepo)
        {
            _usuarioRepo = usuariorepo;
            _empresaRepo = empresaRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto createUsuarioDto, int IdEmpresa)
        {
            if (await _empresaRepo.GetByIdAsync(IdEmpresa) == null)
            {
                return BadRequest($"Não existe empresa de id{IdEmpresa}");
            }
            var usuario = createUsuarioDto.ToCreateUsuarioDto(IdEmpresa);
            await _usuarioRepo.CreateAsync(usuario, IdEmpresa);
            return Ok();
        }

    }
}