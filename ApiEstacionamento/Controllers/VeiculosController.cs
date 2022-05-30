using ApiEstacionamento.Interface.IVeiculos;
using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepository _repository;
        public VeiculosController(IVeiculosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Veiculos")]
        public async Task<IActionResult> RegisterVeiculos([FromBody] VeiculoCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.CreateVeiculos(model);
            if(result == "Dados Criados com Sucesso")
                return Ok(new { message = "Cadastro Efetuado com Sucesso!" });
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Veiculos")]
        public async Task<IActionResult> ReadVeiculos(int Id_User)
        {
            var result = _repository.ReadVeiculosPorDono(Id_User);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        [Route("Veiculos")]
        public async Task<IActionResult> UpdateVeiculos([FromBody] VeiculoUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.UpdateVeiculos(model);
            if (result == "Dados Atualizados com Sucesso")
                return Ok(new { message = "Cadastro Atualizado com Sucesso!" });
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("Veiculos")]
        public async Task<IActionResult> DeleteVeiculos(int Id)
        {
            var result = await _repository.DeleteVeiculos(Id);
            if(result == "Deletado")
                return Ok(new { message = "Cadastro Deletado com Sucesso!" });
            return BadRequest(result);
        }
    }
}
