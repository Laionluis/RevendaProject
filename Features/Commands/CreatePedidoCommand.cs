using MediatR;
using RevendaProject.DTOs;
using RevendaProject.Features.Responses;

namespace RevendaProject.Features.Commands
{
    public class CreatePedidoCommand : IRequest<CreatePedidoResponse>
    {
        public int RevendaId { get; set; }
        public string ClienteIdentificador { get; set; }
        public List<ItemPedidoDTO> Itens { get; set; }
    }
}
