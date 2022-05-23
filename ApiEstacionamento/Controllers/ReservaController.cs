using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ReservaController : Controller
    {
        public ReservaController()
        {

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
