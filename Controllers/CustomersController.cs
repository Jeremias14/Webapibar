using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBar.Data.Interfaces;
using WebApiBar.Models;

namespace WebApiBar.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repocustomer;

        public CustomersController(ICustomerRepository repocustomer)
        {
            _repocustomer = repocustomer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _repocustomer.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _repocustomer.GetCustomersIdAsync(id);
            if(customer == null)
                return NotFound("Producto no encontrado");
            
            return Ok(customer);
        }

        [HttpPost]

        public async Task<IActionResult> Post(Customer customer)
        {
            customer.Dateofcreation = DateTime.Now;
            _repocustomer.Add(customer);
            if(await _repocustomer.SaveAll())
                return Ok(customer);
            return BadRequest();
        }
// Gabriel.majluf@ices.edu.ar

        [HttpPut]

        public async Task<IActionResult> Put(Customer customer)
        {
            var customerToUpdate = await _repocustomer.GetCustomersIdAsync(customer.Id);

            if (customerToUpdate == null)
                return BadRequest("EL id no existe");

            customerToUpdate.Name = customer.Name;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Cellphone = customer.Cellphone;

            if(!await _repocustomer.SaveAll())
                return NoContent();
            
            return Ok(customerToUpdate);
        
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _repocustomer.GetCustomersIdAsync(id);

            if(customer == null)
                return NotFound("Producto no encontrado");
            
            _repocustomer.Delete(customer);
            if(!await _repocustomer.SaveAll())
                return BadRequest("El producto no fue encontrado");
            
            return Ok("Producto borrado");

        }    
    }
}