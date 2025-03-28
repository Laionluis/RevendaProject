using System.ComponentModel.DataAnnotations;

namespace RevendaProject.Models
{
    public class Revenda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string NomeFantasia { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Telefone>? Telefones { get; set; }

        public List<Contato> Contatos { get; set; }

        public List<EnderecoEntrega> EnderecosEntrega { get; set; }
    }

}
