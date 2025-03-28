using System.ComponentModel.DataAnnotations;
using static RevendaProject.Models.Enums;

namespace RevendaProject.Models
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }

        public string ClienteIdentificador { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.UtcNow;

        public PedidoStatus Status { get; set; } = PedidoStatus.Pendente;

        public List<ItemPedido> Itens { get; set; }
    }

}
