using BasicCRUDProductAPI.Queries;
using BusinessObject.Models;
using DataAccessObject;
using MediatR;
using Repository;
using System.Threading;
using System.Threading.Tasks;

namespace BasicCRUDProductAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductsByIdQuery, ServiceResponse<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<Product>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _productRepository.GetProductById(request.Id);
            return res;
        }
    }
}
