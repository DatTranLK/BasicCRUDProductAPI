using BasicCRUDProductAPI.Queries;
using BusinessObject.Models;
using DataAccessObject;
using MediatR;
using Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BasicCRUDProductAPI.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ServiceResponse<List<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var res = await _productRepository.GetProducts();
            return res;
        }
    }
}
