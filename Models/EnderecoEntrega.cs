namespace RevendaProject.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }
        public string Endereco { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }

}
