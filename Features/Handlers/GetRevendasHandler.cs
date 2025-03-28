using MediatR;
using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Queries;
using RevendaProject.Models;

namespace RevendaProject.Features.Handlers
{
    public class GetRevendasHandler : IRequestHandler<GetRevendasQuery, List<Revenda>>
    {
        private readonly AppDbContext _context;

        public GetRevendasHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Revenda>> Handle(GetRevendasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Revendas.ToListAsync();
        }
    }
}
