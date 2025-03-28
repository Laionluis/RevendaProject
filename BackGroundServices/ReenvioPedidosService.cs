using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Commands;
using static RevendaProject.Models.Enums;

namespace RevendaProject.BackGroundServices
{
    public class ReenvioPedidosService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ReenvioPedidosService> _logger;

        public ReenvioPedidosService(IServiceProvider serviceProvider, ILogger<ReenvioPedidosService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("⏱️ Serviço de reenvio de pedidos iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var pedidosFalhados = await context.Pedidos
                    .Where(p => p.Status == PedidoStatus.FalhaEnvio)
                    .ToListAsync(stoppingToken);

                foreach (var pedido in pedidosFalhados)
                {
                    try
                    {
                        _logger.LogInformation($"Tentando reenviar pedido {pedido.Id}");

                        await mediator.Send(new EnviarPedidoCommand
                        {
                            PedidoId = pedido.Id
                        }, stoppingToken);

                        _logger.LogInformation($"✅ Pedido {pedido.Id} reenviado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"❌ Falha ao reenviar pedido {pedido.Id}: {ex.Message}");
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken); 
            }
        }
    }
}
