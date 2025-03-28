using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Queries;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class GetPedidosByRevendaHandler : IRequestHandler<GetPedidosByRevendaQuery, List<Pedido>>
    {
        private readonly AppDbContext _context;

        public GetPedidosByRevendaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> Handle(GetPedidosByRevendaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pedidos
                .Where(p => p.RevendaId == request.RevendaId)
                .Include(p => p.Itens)
                .ToListAsync();
        }
    }
}
