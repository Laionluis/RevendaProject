using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.DTOs;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Responses;
using RevendaProject.Models;
using static RevendaProject.Models.Enums;

namespace RevendaProject.Features.Handlers
{
    public class EnviarPedidoHandler : IRequestHandler<EnviarPedidoCommand, PedidoResponse>
    {
        private readonly AppDbContext _context;

        public EnviarPedidoHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoResponse> Handle(EnviarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == request.PedidoId);

            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            var totalUnidades = pedido.Itens.Sum(i => i.Quantidade);
            if (totalUnidades < 1000)
                throw new Exception("Pedido não pode ser enviado. Mínimo de 1000 unidades.");

            try
            {
                // Simulação de instabilidade
                var apiIndisponivel = new Random().Next(0, 4) == 0;

                if (apiIndisponivel)
                    throw new Exception("API está indisponível.");

                // Sucesso na "API"
                pedido.Status = PedidoStatus.Enviado;
                _context.LogTentativasEnvio.Add(new LogTentativaEnvio
                {
                    PedidoId = pedido.Id,
                    Sucesso = true
                });

                await _context.SaveChangesAsync();

                return new PedidoResponse
                {
                    CodigoPedido = pedido.Id,
                    Itens = pedido.Itens.Select(i => new ItemPedidoDTO
                    {
                        Produto = i.Produto,
                        Quantidade = i.Quantidade
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                pedido.Status = PedidoStatus.FalhaEnvio;
                _context.LogTentativasEnvio.Add(new LogTentativaEnvio
                {
                    PedidoId = pedido.Id,
                    Sucesso = false,
                    MensagemErro = ex.Message
                });

                await _context.SaveChangesAsync();
                throw; // continua retornando erro para a controller
            }
        }
    }
}
