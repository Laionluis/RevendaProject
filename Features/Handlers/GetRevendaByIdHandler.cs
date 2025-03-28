using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Queries;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class GetRevendaByIdHandler : IRequestHandler<GetRevendaByIdQuery, Revenda>
    {
        private readonly AppDbContext _context;

        public GetRevendaByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Revenda> Handle(GetRevendaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Revendas
                .Include(r => r.Telefones)
                .Include(r => r.Contatos)
                .Include(r => r.EnderecosEntrega)
                .FirstOrDefaultAsync(r => r.Id == request.Id);
        }
    }
}
