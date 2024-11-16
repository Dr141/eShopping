using System.ComponentModel.DataAnnotations;

namespace Modelo.Autenticacao.DTOs.Resquest;

public record UsuarioAtualizarSenhaResquest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string SenhaAtual { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string NovaSenha { get; set; }

    [Compare(nameof(NovaSenha), ErrorMessage = "As senhas devem ser iguais")]
    public string SenhaConfirmacao { get; set; }

    public UsuarioAtualizarSenhaResquest(string email, string senhaAtual, string novaSenha, string senhaConfirmacao)
    {
        Email = email;
        SenhaAtual = senhaAtual;
        NovaSenha = novaSenha;
        SenhaConfirmacao = senhaConfirmacao;
    }
}
