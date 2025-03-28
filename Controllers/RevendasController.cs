using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Queries;

namespace RevendaProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RevendasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RevendasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra uma nova revenda com seus dados completos.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRevendaCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var revendaId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = revendaId }, new { id = revendaId });
        }

        /// <summary>
        /// Consulta uma revenda cadastrada pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetRevendaByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
