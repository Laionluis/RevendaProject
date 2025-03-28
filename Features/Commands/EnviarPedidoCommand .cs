using MediatR;
using RevendaProject.Features.Responses;

namespace RevendaProject.Features.Commands
{
    public class EnviarPedidoCommand : IRequest<PedidoResponse>
    {
        public Guid PedidoId { get; set; } 
    }
}
