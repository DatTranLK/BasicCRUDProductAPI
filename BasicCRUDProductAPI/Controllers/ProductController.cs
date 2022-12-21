using BasicCRUDProductAPI.Commands;
using BasicCRUDProductAPI.Queries;
using BusinessObject.Models;
using DataAccessObject;
using MediatR;
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
        private readonly IMediator _mediator;

        public ProductController(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            try
            {
                var query = new GetProductsQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
                /*var res = await _productRepository.GetProducts();
                return StatusCode((int)res.StatusCode, res);*/
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
                var query = new GetProductsByIdQuery(id);
                var result = await _mediator.Send(query);
                return StatusCode((int)result.StatusCode, result);
                /*var res = await _productRepository.GetProductById(id);
                return StatusCode((int)res.StatusCode, res);*/
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
        /// - productId, productName, CategoryId, weight  are required when adding
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<string>>> AddNewProduct([FromBody] AddNewProductCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return StatusCode((int)result.StatusCode, result);
                /*var res = await _productRepository.AddNewProduct(product);
                return StatusCode((int)res.StatusCode, res);*/
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
