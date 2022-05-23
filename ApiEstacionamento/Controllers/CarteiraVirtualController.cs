using ApiEstacionamento.Interface.ICarteiraVirtual;
using ApiEstacionamento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CarteiraVirtualController : Controller
    {
        private readonly ICarteiraVirtual _context; 
        public CarteiraVirtualController(ICarteiraVirtual context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CarteiraVirtual")]
        public async Task<IActionResult> RegisterCarteiraVirtual([FromBody] NovaCarteiraVirtual model)
        {
            var result = await _context.RegisterCarteiraVirtual(model);
            if(result == "Sucesso")
                return Ok(new { message = "Cadastro Efetuado com Sucesso!" });
            
            return BadRequest(new { message = $"Erro: {result}, tente novamente mais tarde" });
        }

        [HttpGet]
        [Route("CarteiraVirtual")]
        public IActionResult ReadCarteiraVirtual(int UserId)
        {
            var result = _context.ReadCarteiraVirtual(UserId);
            
            return Ok(result.Result);
        }

        [HttpPut]
        [Route("CarteiraVirtualTransferencia")]
        public async Task<IActionResult> TransferenciaCarteiraVirtual([FromBody] CarteiraVirtualTransferencia model)
        {
            var result = await _context.TransferenciaCarteiraVirtual(model);
            if (result == "Pagamento Efetuado com Sucesso")
                return Ok(new { message = "Pagamento Efetuado com Sucesso!" });
            else if (result == "Falta de Crédito na Carteira")
                return Ok(new { message = "Falta de Crédito na Carteira!" });

            return BadRequest(new { message = $"Erro: {result}, tente novamente mais tarde" });
        }
        [HttpPost]
        [Route("CarteiraVirtualAddCreditos")]
        public async Task<IActionResult> TransferenciaEntradaCarteiraVirtual([FromBody] TransferenciaEntradaCarteiraVirtual model)
        {
            var result = await _context.TransferenciaEntradaCarteiraVirtual(model);
            if (result == "Credito Adicionado com Sucesso")
                return Ok(new { message = "Créditos Adicionado com Sucesso!" });

            return BadRequest(new { message = $"Erro: {result}, tente novamente mais tarde" });
        }
        [HttpPost]
        [Route("CarteiraVirtualSaidaCreditos")]
        public async Task<IActionResult> TransferenciaSaidaCarteiraVirtual([FromBody] TransferenciaEntradaCarteiraVirtual model)
        {
            var result = await _context.TransferenciaSaidaCarteiraVirtual(model);
            if (result == "Credito Removido com Sucesso")
                return Ok(new { message = "Créditos Removido com Sucesso!" });
            else if(result == "Falta de Crédito na Carteira")
                return Ok(new { message = "Falta de Crédito na Carteira!" });

            return BadRequest(new { message = $"Erro: {result}, tente novamente mais tarde" });
        }
    }
}
