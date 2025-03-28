using MediatR;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Responses;

namespace RevendaProject.Features.Handlers
{
    public class ReenviarPedidoHandler : IRequestHandler<ReenviarPedidoCommand, PedidoResponse>
    {
        private readonly IMediator _mediator;

        public ReenviarPedidoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PedidoResponse> Handle(ReenviarPedidoCommand request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EnviarPedidoCommand
            {
                PedidoId = request.PedidoId
            });
        }
    }
}
