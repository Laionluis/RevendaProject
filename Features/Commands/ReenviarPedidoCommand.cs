using MediatR;
using RevendaProject.Features.Responses;

namespace RevendaProject.Features.Commands
{
    public class ReenviarPedidoCommand : IRequest<PedidoResponse>
    {
        public Guid PedidoId { get; set; }
    }
}
