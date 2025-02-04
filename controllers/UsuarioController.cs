using FluentResults;
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
                return NotFound($"Não existe empresa com ID {IdEmpresa}.");
            }
            var usuario = createUsuarioDto.ToCreateUsuarioDto(IdEmpresa);

            var result = await _usuarioRepo.CreateAsync(usuario, IdEmpresa);
            if (result.IsFailed)
            {
                return BadRequest(new { Erros = result.Errors.Select(e => e.Message) });
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByIdEmpresa(int IdEmpresa)
        {
            var usuarios = await _usuarioRepo.GetUsuariosByEmpresa(IdEmpresa);
            if (!usuarios.IsSuccess)
            {
                return NotFound(new { message = usuarios.Errors });
            }
            return Ok(usuarios.Value);
        }

        [HttpPut("{idUsuario}:int")]
        public async Task<IActionResult> UpdateUsuario([FromBody] UpdateUsuarioDto updateUsuarioDto, [FromRoute] int idUsuario, int IdEmpresa)
        {
            if (await _empresaRepo.GetByIdAsync(IdEmpresa) == null)
            {
                return NotFound($"Não existe empresa de id{IdEmpresa}");
            }
            var result = await _usuarioRepo.UpdateAsync(updateUsuarioDto, idUsuario, IdEmpresa);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Value);
        }

        [HttpPatch("{idUsuario:int}")]
        public async Task<IActionResult> UpdateSenhaUsuario([FromBody] UpdateSenhaUsuarioDto updateSenhaUsuarioDto, [FromRoute] int idUsuario, int IdEmpresa)
        {
            if (await _empresaRepo.GetByIdAsync(IdEmpresa) == null)
            {
                return NotFound($"Não existe empresa de id{IdEmpresa}");
            }
            var result = await _usuarioRepo.UpdateSenhaAsync(updateSenhaUsuarioDto, idUsuario, IdEmpresa);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }
    }
}