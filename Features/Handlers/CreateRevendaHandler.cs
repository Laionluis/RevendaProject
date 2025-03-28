using MediatR;
using RevendaProject.Data;
using RevendaProject.Features.Commands;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class CreateRevendaHandler : IRequestHandler<CreateRevendaCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateRevendaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRevendaCommand request, CancellationToken cancellationToken)
        {
            var revenda = new Revenda
            {
                CNPJ = request.CNPJ,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Email = request.Email,
                Telefones = request.Telefones?.Select(t => new Telefone { Numero = t }).ToList(),
                Contatos = request.Contatos?.Select(c => new Contato { Nome = c, Principal = false }).ToList(),
                EnderecosEntrega = request.EnderecosEntrega?.Select(e => new EnderecoEntrega { Endereco = e }).ToList()
            };

            _context.Revendas.Add(revenda);
            await _context.SaveChangesAsync(cancellationToken);
            return revenda.Id;
        }
    }
}
