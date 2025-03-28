using RevendaProject.DTOs;

namespace RevendaProject.Features.Responses
{
    public class PedidoResponse
    {
        public Guid CodigoPedido { get; set; }
        public List<ItemPedidoDTO> Itens { get; set; }
    }
}
