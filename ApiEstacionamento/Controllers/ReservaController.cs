using ApiEstacionamento.Data.Context;
using ApiEstacionamento.Interface.IReserva;
using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _repository;
        public ReservaController(IReservaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Reservas")]
        public async Task<IActionResult> RegisterReserva([FromBody] ReservaCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.CreateReserva(model);
            if (result == "Reserva Criada com Sucesso")
                return Ok(new { message = "Reserva Efetuado com Sucesso!" });
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Reservas")]
        public IActionResult ReadReserva(int IdUser)
        {
            var result = _repository.ReadReserva(IdUser);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        [Route("Reservas")]
        public async Task<IActionResult> UpdateReserva([FromBody] ReservaUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Alguma coisa falhou :( \n Tente Novamente");
            var result = await _repository.UpdateReserva(model);
            if (result == "Reserva Atualizada com Sucesso")
                return Ok(new { message = "Reserva Atualizada com Sucesso!" });
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("Reservas")]
        public async Task<IActionResult> DeleteReserva(int IdReserva)
        {
            var result = await _repository.DeleteReserva(IdReserva);
            if (result == "Deletado com Sucesso!")
                return Ok(result);
            return BadRequest(result);
        }
    }
}
