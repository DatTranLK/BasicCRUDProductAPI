using BusinessObject.Models;
using DataAccessObject;
using MediatR;

namespace BasicCRUDProductAPI.Queries
{
    public class GetProductsByIdQuery : IRequest<ServiceResponse<Product>>
    {
        public int Id { get; set; }
        public GetProductsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
