using MediatR;
using RevendaProject.Models;

namespace RevendaProject.Features.Queries
{
    public class GetPedidoByIdQuery : IRequest<Pedido>
    {
        public Guid Id { get; set; }

        public GetPedidoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
