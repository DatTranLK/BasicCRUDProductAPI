using BusinessObject.Models;
using DataAccessObject;
using MediatR;

namespace BasicCRUDProductAPI.Commands
{
    public class AddNewProductCommand : IRequest<ServiceResponse<string>>
    {
        public Product Product { get; set; }
    }
}
