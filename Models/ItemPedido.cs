namespace RevendaProject.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public string Produto { get; set; }
        public int Quantidade { get; set; }

        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }

}
