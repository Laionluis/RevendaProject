using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.DTOs;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Handlers;
using Xunit;

namespace RevendaProject.Tests
{
    public class CreatePedidoHandlerTests
    {
        private readonly AppDbContext _context;
        private readonly CreatePedidoHandler _handler;

        public CreatePedidoHandlerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // banco isolado por teste
                .Options;

            _context = new AppDbContext(options);
            _handler = new CreatePedidoHandler(_context);
        }

        [Fact]
        public async Task Deve_CriarPedido_Quando_DadosValidos()
        {
            var command = new CreatePedidoCommand
            {
                RevendaId = 1,
                ClienteIdentificador = "cliente-xyz",
                Itens =
                [
                    new() { Produto = "Cerveja", Quantidade = 600 },
                    new() { Produto = "Água", Quantidade = 400 }
                ]
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var pedido = await _context.Pedidos.FindAsync(result.PedidoId);
            Assert.NotNull(pedido);
            Assert.Equal("cliente-xyz", pedido.ClienteIdentificador);
            Assert.Equal(2, pedido.Itens.Count);
        }
    }
}
