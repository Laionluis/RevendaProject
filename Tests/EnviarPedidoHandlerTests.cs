using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Models;
using static RevendaProject.Models.Enums;
using Xunit;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Handlers;

namespace RevendaProject.Tests
{
    public class EnviarPedidoHandlerTests
    {
        private readonly AppDbContext _context;
        private readonly EnviarPedidoHandler _handler;

        public EnviarPedidoHandlerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "a_test")
                .Options;

            _context = new AppDbContext(options);
            _handler = new EnviarPedidoHandler(_context);
        }

        [Fact]
        public async Task Deve_EnviarPedido_Quando_TotalMaiorQue1000()
        {
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                ClienteIdentificador = "teste",
                RevendaId = 1,
                DataPedido = DateTime.UtcNow,
                Status = PedidoStatus.Pendente,
                Itens =
                [
                    new() { Produto = "Produto 1", Quantidade = 600 },
                    new() { Produto = "Produto 2", Quantidade = 500 }
                ]
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            var command = new EnviarPedidoCommand { PedidoId = pedido.Id };

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.Equal(pedido.Id, response.CodigoPedido);
            Assert.Equal(2, response.Itens.Count);

            var pedidoDb = await _context.Pedidos.FindAsync(pedido.Id);
            Assert.Equal(PedidoStatus.Enviado, pedidoDb.Status);
        }
    }

}
