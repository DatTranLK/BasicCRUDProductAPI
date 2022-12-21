using BasicCRUDProductAPI.Commands;
using DataAccessObject;
using MediatR;
using Repository;
using System.Threading;
using System.Threading.Tasks;

namespace BasicCRUDProductAPI.Handlers
{
    public class AddNewProductHandler : IRequestHandler<AddNewProductCommand, ServiceResponse<string>>
    {
        private readonly IProductRepository _productRepository;

        public AddNewProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<string>> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            var res = await _productRepository.AddNewProduct(request.Product);
            return res;
        }
    }
}
