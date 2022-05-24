using ApiEstacionamento.Interface.IEstacionamento;
using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class EstacionamentoController : Controller
    {
        private readonly IEstacionamentoRepository _repository;
        public EstacionamentoController(IEstacionamentoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Estacionamento")]
        public async Task<IActionResult> RegisterEstacionamento([FromBody] EstacionamentoCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.EstacionamentoCreate(model);
            if (result == "Criado com Sucesso!")
                return Ok(new { message = "Cadastro Efetuado com Sucesso!" });
            return BadRequest(result);
        }

        [HttpGet]
        [Route("EstacionamentoEspecifico")]
        public async Task<IActionResult> EstacionamentoReadEspecifico(int EstacionamentoId)
        {
            var result = await _repository.EstacionamentoReadEspecifico(EstacionamentoId);
            if (result != null)
                return Ok(result);
            return BadRequest(new {message="Ops parece que houve um problema, tente novamente mais tarde!"});
        }

        [HttpGet]
        [Route("EstacionamentoGeral")]
        public async Task<IActionResult> EstacionamentoReadGeral()
        {
            var result = await _repository.EstacionamentoReadGeral();
            if (result != null)
                return Ok(result);
            return BadRequest(new { message = "Ops parece que houve um problema, tente novamente mais tarde!" });
        }

        [HttpPut]
        [Route("Estacionamento")]
        public async Task<IActionResult> UpdateEstacionamento([FromBody] EstacionamentoUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.EstacionamentoUpdate(model);
            if (result == "Alteracoes Efetuadas Com Sucesso")
                return Ok(new { message = "Cadastro Atualizado com Sucesso!" });
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("Estacionamento")]
        public IActionResult DeleteEstacionamento(Guid Id)
        {
            return Ok("");
        }
    }
}
