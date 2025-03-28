using MediatR;
using RevendaProject.Data;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Responses;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, CreatePedidoResponse>
    {
        private readonly AppDbContext _context;

        public CreatePedidoHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreatePedidoResponse> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                RevendaId = request.RevendaId,
                ClienteIdentificador = request.ClienteIdentificador,
                DataPedido = DateTime.UtcNow,
                Itens = request.Itens.Select(i => new ItemPedido
                {
                    Produto = i.Produto,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatePedidoResponse
            {
                PedidoId = pedido.Id,
                Itens = request.Itens
            };
        }
    }
}
