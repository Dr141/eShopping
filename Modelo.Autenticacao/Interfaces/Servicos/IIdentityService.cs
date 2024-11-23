﻿using Modelo.Autenticacao.DTOs.Response;
using Modelo.Autenticacao.DTOs.Resquest;

namespace Modelo.Autenticacao.Interfaces.Servicos;

/// <summary>
/// Interface para padronizar a implementação da classe de autenticação com Identity.
/// </summary>
public interface IIdentityService
{
    Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
    Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
    Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
    Task<UsuarioCadastroResponse> AdicionarRole(UsuarioRoleRequest usuarioRole);
    Task<UsuarioCadastroResponse> RemoverRole(UsuarioRoleRequest usuarioRole);
    Task<UsuarioCadastroResponse> AdicionarClaim(UsuarioClaimRequest usuarioClaim);
    Task<UsuarioCadastroResponse> RemoverClaim(UsuarioClaimRequest usuarioClaim);
    Task<UsuarioCadastroResponse> AtualizarSenha(UsuarioAtualizarSenhaResquest usuarioLoginAtualizarSenha, string email);
    Task<UsuarioCadastroResponse> AtualizarSenhaInterno(UsuarioCadastroRequest usuarioLoginAtualizarSenha);
    Task<UsuariosResponse> ObterTodosUsuarios();
}
