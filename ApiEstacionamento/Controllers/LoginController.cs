using ApiEstacionamento.Interface.ILogin;
using ApiEstacionamento.Model;
using ApiEstacionamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _login;
        CreateHashEncrypting encripty = new CreateHashEncrypting();
        public LoginController(ILoginRepository login)
        {
            _login = login;
        }
        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _login.Register(model);
            if(result)
                return Ok(new {message="Cadastro Efetuado com Sucesso!"});
            return BadRequest(result);
        }
        [HttpGet]
        [Route("Usuario")]
        public async Task<IActionResult> LogarUsuario(string Login, string Senha)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var senhaCriptografada = encripty.GerarHashSha256(Senha);

            var access = await _login.Login(Login, senhaCriptografada);
            if(access)
                return Ok("Usuário Logado");

            return Ok("Usuário ou Senha Inválidos");
        }
        [HttpPut]
        [Route("Usuario")]
        public async Task<IActionResult> AlterarUsuario(AlterLoginExistingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");

            var senhaCriptografada = encripty.GerarHashSha256(model.Senha);
            var senhaNovaCriptografada = encripty.GerarHashSha256(model.NovaSenha);

            model.NovaSenha = senhaNovaCriptografada;
            model.Senha = senhaCriptografada;

            var result = await _login.AlterLoginExisting(model);
            if (result) 
                return Ok("Sucesso! Usuário Alterado");

            return Ok("Usuário não alterado, consulte login e senha");
        }
        [HttpDelete]
        [Route("Usuario")]
        public async Task<IActionResult> DeletarUsuario()
        {
            return Ok("Deletado Usuário Debora");
        }
    }
}
