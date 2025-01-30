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
            // Validação se a empresa existe
            if (await _empresaRepo.GetByIdAsync(IdEmpresa) == null)
            {
                return NotFound($"Não existe empresa com ID {IdEmpresa}.");
            }

            // Converte DTO para Model
            var usuario = createUsuarioDto.ToCreateUsuarioDto(IdEmpresa);

            // Tenta criar o usuário
            var result = await _usuarioRepo.CreateAsync(usuario, IdEmpresa);

            // Se falhar, retorna os erros
            if (result.IsFailed)
            {
                return BadRequest(new { Erros = result.Errors.Select(e => e.Message) });
            }

            return Ok(usuario);
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
    }
}