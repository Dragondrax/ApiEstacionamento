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
        public ReservaController(IReservaRepository _repository)
        {
            _repository = _repository;
        }

        [HttpPost]
        [Route("Reservas")]
        public IActionResult RegisterReserva([FromBody] Reserva model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("Reservas")]
        public IActionResult ReadReserva()
        {
            return Ok("");
        }

        [HttpPut]
        [Route("Reservas")]
        public IActionResult UpdateReserva([FromBody] Reserva model)
        {
            return Ok("");
        }

        [HttpDelete]
        [Route("Reservas")]
        public IActionResult DeleteReserva(Guid Id)
        {
            return Ok("");
        }
    }
}
