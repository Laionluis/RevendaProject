using MediatR;
using RevendaProject.Models;

namespace RevendaProject.Features.Queries
{
    public class GetRevendasQuery : IRequest<List<Revenda>> { }
}
