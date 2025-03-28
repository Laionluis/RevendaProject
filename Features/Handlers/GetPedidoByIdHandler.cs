using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Queries;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, Pedido>
    {
        private readonly AppDbContext _context;

        public GetPedidoByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
        }
    }
}
