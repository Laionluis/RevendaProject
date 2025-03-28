namespace RevendaProject.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }

}
