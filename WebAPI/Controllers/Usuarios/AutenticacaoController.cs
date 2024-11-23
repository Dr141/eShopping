using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Autenticacao.DTOs.Response;
using Modelo.Autenticacao.DTOs.Resquest;
using Modelo.Autenticacao.Interfaces.Servicos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers.Usuarios;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IIdentityService _identity;

    public AutenticacaoController(IIdentityService identity) => _identity = identity;

    [ProducesResponseType(typeof(UsuarioLoginResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [AllowAnonymous]
    [HttpGet("Login")]
    public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _identity.Login(usuario);

                if (result.Sucesso)
                    return Ok(result);

                return BadRequest(result.Erros);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [AllowAnonymous]
    [HttpPost("Cadastro")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest cadastro)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _identity.CadastrarUsuario(cadastro);

                if (result.Sucesso)
                    return Ok(result);

                return BadRequest(result.Erros);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("AtualizarSenha")]
    public async Task<ActionResult<UsuarioCadastroResponse>> AtualizarSenha(UsuarioAtualizarSenhaResquest atualizarSenha)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (atualizarSenha.SenhaAtual.Equals(atualizarSenha.NovaSenha, StringComparison.CurrentCultureIgnoreCase))
                    return BadRequest("A nova senha deve ser diferente da senha atual.");
                var result = await _identity.AtualizarSenha(atualizarSenha);

                if (result.Sucesso)
                    return Ok(result);

                return BadRequest(result.Erros);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
    }
}