using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<ServiceResponse<string>> AddNewProduct(Product product) => ProductDAO.Instance.AddNewProduct(product);

        public Task<ServiceResponse<string>> DeleteProduct(int id) => ProductDAO.Instance.DeleteProduct(id);

        public Task<ServiceResponse<Product>> GetProductById(int id) => ProductDAO.Instance.GetProductById(id);

        public Task<ServiceResponse<List<Product>>> GetProducts() => ProductDAO.Instance.GetProducts();

        public Task<ServiceResponse<string>> UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
