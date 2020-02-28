using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using tokentutor.Models;

namespace tokentutor.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly CustomerProductContext _context;

        public ProductController(ILogger<ProductController> logger, CustomerProductContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var product = _context.Products;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = product
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var product = _context.Products.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = product
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var product = _context.Products.First(i => i.Id == id);

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

      [HttpPut("{id}")]
        public IActionResult Put(int id, Product productPut){
            var product = _context.Products.First(i => i.Id == id);

            product.Name = productPut.Name;
            product.Price = productPut.Price;
            product.Created_at = product.Created_at;
            product.Updated_at = DateTime.Now;

            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product){  
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = product
            });
        }

    }
}