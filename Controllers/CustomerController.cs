using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using tokentutor.Models;  
// using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace tokentutor.Controllers
{
    [ApiController]
    [Authorize]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {

        // private readonly ILogger<CustomerController> _logger;
        private readonly CustomerProductContext _context;

        public CustomerController(CustomerProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            List<Object> requireData = new List<object>();
            var customer = _context.Customers;
            foreach(var x in customer){
                requireData.Add(new{ x.Id, x.Full_name, x.Username, x.Email, x.Phone_number});
            }

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = requireData
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var customer = _context.Customers.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = customer
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var customer = _context.Customers.First(i => i.Id == id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customerPut){
            var customer = _context.Customers.First(i => i.Id == id);

            customer.Full_name = customerPut.Full_name;
            customer.Username = customerPut.Username;
            customer.Email = customerPut.Email;
            customer.Phone_number = customerPut.Phone_number;
            customer.Created_at = customer.Created_at;
            customer.Updated_at = DateTime.Now;

            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer){
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = customer
            });
        }

    }
}