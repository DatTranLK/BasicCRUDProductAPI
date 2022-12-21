using BusinessObject.Models;
using DataAccessObject;
using MediatR;
using System.Collections.Generic;

namespace BasicCRUDProductAPI.Queries
{
    public class GetProductsQuery : IRequest<ServiceResponse<List<Product>>>
    {
        
    }
}
