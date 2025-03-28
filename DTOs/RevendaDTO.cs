using System.ComponentModel.DataAnnotations;

namespace RevendaProject.DTOs
{
    public class RevendaDTO
    {
        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string NomeFantasia { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<string> Telefones { get; set; } = new();

        [Required]
        public List<string> Contatos { get; set; }

        [Required]
        public List<string> EnderecosEntrega { get; set; }
    }
}
