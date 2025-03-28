using MediatR;
using RevendaProject.Models;

namespace RevendaProject.Features.Queries
{
    public class GetPedidosByRevendaQuery : IRequest<List<Pedido>>
    {
        public int RevendaId { get; set; }

        public GetPedidosByRevendaQuery(int revendaId)
        {
            RevendaId = revendaId;
        }
    }
}
