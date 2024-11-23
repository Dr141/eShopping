### Projeto para controle de estoque/vendas.
---

### Métodos de autenticação
1. Realizar autenticação devemos chamar o método: `Login(UsuarioLoginRequest usuario)`
2. Cadastrar novo usuário devemos chamar o método:`Cadastrar(UsuarioCadastroRequest cadastro)`
3. Atualizar senha: `AtualizarSenha(UsuarioAtualizarSenhaResquest atualizarSenha)`
4. Atualizar token expirado `AtualizarToken()`

### Método para controle de usuário(necessário `Role("Administrador")`)
1. Obter todos usuários: `ObterTodos()`
2. Atualizar senha: `AtualizarSenha(UsuarioCadastroRequest atualizarSenha)`
3. Adicionar role: `AdicionarRole(UsuarioRoleRequest adicionarRole)`
4. Remover role: `RemoverRole(UsuarioRoleRequest removerRole)`
5. Adicionar claim: `AdicionarClaim(UsuarioClaimRequest adicionarClaim)`
6. Remover claim: `RemoverClaim(UsuarioClaimRequest removerClaim)`
