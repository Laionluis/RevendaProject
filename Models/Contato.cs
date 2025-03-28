namespace RevendaProject.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool Principal { get; set; } 

        public int RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }

}
