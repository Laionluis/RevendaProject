using RevendaProject.DTOs;

namespace RevendaProject.Features.Responses
{
    public class CreatePedidoResponse
    {
        public Guid PedidoId { get; set; }
        public List<ItemPedidoDTO> Itens { get; set; }
    }

}
