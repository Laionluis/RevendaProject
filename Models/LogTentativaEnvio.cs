namespace RevendaProject.Models
{
    public class LogTentativaEnvio
    {
        public int Id { get; set; }
        public Guid PedidoId { get; set; }
        public DateTime DataTentativa { get; set; } = DateTime.UtcNow;
        public bool Sucesso { get; set; }
        public string? MensagemErro { get; set; }
    }
}
