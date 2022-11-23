using BusinessObject.Models;
using DataAccessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRUDProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            try
            {
                var res = await _productRepository.GetProducts();
                return StatusCode((int)res.StatusCode, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsById(int id)
        {
            try
            {
                var res = await _productRepository.GetProductById(id);
                return StatusCode((int)res.StatusCode, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteProduct(int id)
        {
            try
            {
                var res = await _productRepository.DeleteProduct(id);
                return StatusCode((int)res.StatusCode, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        /// <summary>
        /// Add new Product with information include productId, productName, CategoryId, weight, unitPrice, unitsInStock
        /// </summary>
        /// 
        /// <remarks>
        /// Description: 
        /// - productId, productName, CategoryId  are required when adding
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<string>>> AddNewProduct(Product product)
        {
            try
            {
                var res = await _productRepository.AddNewProduct(product);
                return StatusCode((int)res.StatusCode, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        /// <summary>
        /// Update Product with information include productId, productName, CategoryId, weight, unitPrice, unitsInStock
        /// </summary>
        /// 
        /// <remarks>
        /// Description: 
        /// - productId is required when update
        /// </remarks>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateProduct(Product product)
        {
            try
            {
                var res = await _productRepository.UpdateProduct(product);
                return StatusCode((int)res.StatusCode, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
