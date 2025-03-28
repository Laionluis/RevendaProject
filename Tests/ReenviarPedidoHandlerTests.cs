using MediatR;
using Moq;
using RevendaProject.DTOs;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Handlers;
using RevendaProject.Features.Responses;
using Xunit;

namespace RevendaProject.Tests
{
    public class ReenviarPedidoHandlerTests
    {
        [Fact]
        public async Task Deve_Reenviar_Pedido_Utilizando_Handler_De_Envio()
        {
            var pedidoId = Guid.NewGuid();

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<EnviarPedidoCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new PedidoResponse
                         {
                             CodigoPedido = pedidoId,
                             Itens = new List<ItemPedidoDTO>
                             {
                                new() { Produto = "Produto 1", Quantidade = 1000 }
                             }
                         });

            var handler = new ReenviarPedidoHandler(mediatorMock.Object);

            var response = await handler.Handle(new ReenviarPedidoCommand { PedidoId = pedidoId }, CancellationToken.None);

            Assert.Equal(pedidoId, response.CodigoPedido);
            Assert.Single(response.Itens);
        }
    }

}
