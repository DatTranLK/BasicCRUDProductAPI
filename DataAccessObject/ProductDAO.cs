using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        FStoreDBContext _dbContext = new FStoreDBContext(); 
        public ProductDAO()
        {

        }
        public static ProductDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            try
            {
                var pro = await _dbContext.Products
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.ProductId)
                    .ToListAsync();
                if (pro.Count > 0)
                {
                    return new ServiceResponse<List<Product>>
                    {
                        Data = pro,
                        Message = "Successfully",
                        Success = true,
                        StatusCode = 200
                    };
                }
                return new ServiceResponse<List<Product>>
                {
                    Message = "Failed",
                    Success = false,
                    StatusCode = 400
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            try
            {
                var pro = await _dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
                if (pro != null)
                {
                    return new ServiceResponse<Product>
                    { 
                        Data = pro,
                        Success = true,
                        StatusCode = 200,
                        Message = "Successfully"
                    };
                }
                return new ServiceResponse<Product>
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Can not found any product with id = " + id
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResponse<string>> DeleteProduct(int id)
        {
            try
            {
                var pro = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                if (pro != null)
                {
                    _dbContext.Products.Remove(pro);
                    await _dbContext.SaveChangesAsync();
                    return new ServiceResponse<string>
                    {
                        Message = "Successfully",
                        Success = true,
                        StatusCode = 200
                    };
                }
                return new ServiceResponse<string>
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Can not found any product with id = " + id
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResponse<string>> AddNewProduct(Product product)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Successfully",
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResponse<string>> UpdateProduct(Product product)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(product).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(true);
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Successfully",
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
