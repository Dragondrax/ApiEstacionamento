using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class VeiculosController : Controller
    {
        public VeiculosController()
        {

        }

        [HttpPost]
        [Route("Veiculos")]
        public IActionResult RegisterReserva([FromBody] Carro model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("Veiculos")]
        public IActionResult ReadReserva()
        {
            return Ok("");
        }

        [HttpPut]
        [Route("Veiculos")]
        public IActionResult UpdateReserva([FromBody] Carro model)
        {
            return Ok("");
        }

        [HttpDelete]
        [Route("Veiculos")]
        public IActionResult DeleteReserva(Guid Id)
        {
            return Ok("");
        }
    }
}
