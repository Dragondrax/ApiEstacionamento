using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class EstacionamentoController : Controller
    {
        public EstacionamentoController()
        {

        }

        [HttpPost]
        [Route("Estacionamento")]
        public IActionResult RegisterEstacionamento([FromBody] Estacionamento model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("Estacionamento")]
        public IActionResult ReadEstacionamento()
        {
            return Ok("");
        }

        [HttpPut]
        [Route("Estacionamento")]
        public IActionResult UpdateEstacionamento([FromBody] Estacionamento model)
        {
            return Ok("");
        }

        [HttpDelete]
        [Route("Estacionamento")]
        public IActionResult DeleteEstacionamento(Guid Id)
        {
            return Ok("");
        }
    }
}
