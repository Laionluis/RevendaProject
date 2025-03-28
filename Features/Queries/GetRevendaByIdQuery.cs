using MediatR;
using RevendaProject.Models;

namespace RevendaProject.Features.Queries
{
    public class GetRevendaByIdQuery : IRequest<Revenda>
    {
        public int Id { get; set; }

        public GetRevendaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
