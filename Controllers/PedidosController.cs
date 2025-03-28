using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevendaProject.Features.Commands;

namespace RevendaProject.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePedidoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{id}/enviar-pedido")]
        public async Task<IActionResult> EnviarParaAmbev(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new EnviarPedidoCommand { PedidoId = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(503, new { erro = ex.Message });
            }
        }

        [HttpPost("{id}/reenviar")]
        public async Task<IActionResult> Reenviar(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new ReenviarPedidoCommand { PedidoId = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(503, new { erro = ex.Message });
            }
        }
    }
}
