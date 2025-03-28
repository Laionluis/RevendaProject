using MediatR;

namespace RevendaProject.Features.Commands
{
    public class CreateRevendaCommand : IRequest<int>
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public List<string> Telefones { get; set; }
        public List<string> Contatos { get; set; }
        public List<string> EnderecosEntrega { get; set; }
    }
}
