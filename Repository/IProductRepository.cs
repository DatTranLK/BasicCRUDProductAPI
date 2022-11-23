using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<string>> DeleteProduct(int id);
        Task<ServiceResponse<string>> AddNewProduct(Product product);
        Task<ServiceResponse<string>> UpdateProduct(Product product);
    }
}
