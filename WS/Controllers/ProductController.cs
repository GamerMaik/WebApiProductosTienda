using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using LN.Interfaces;

namespace WS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var allProducts = _productService.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data");
            }

            var addedProduct = _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = addedProduct.Id }, addedProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data");
            }

            var updated = _productService.UpdateProduct(product);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _productService.DeleteProduct(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
