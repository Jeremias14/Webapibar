using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBar.Data.Interfaces;
using WebApiBar.Dtos;
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
        public async Task<IActionResult> GetIdCustomer(int id)
        {
            var customer = await _repocustomer.GetCustomersIdAsync(id);
            
            if(customer == null)
                return NotFound("Cliente no encontrado"); 
            
            var customerDto = new CustomerGetDto();
            customerDto.Id = customer.Id;
            customerDto.Name = customer.Name;
            customerDto.Address = customer.Address;
            customerDto.Cellphone = customer.Cellphone;
            
            return Ok(customerDto);
        }
        
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetNameCustomer(string name)
        {
            var customer = await _repocustomer.GetCustomersNameAsync(name);
            if(customer == null)
                return NotFound("Producto no encontrado");
            
            return Ok(customer);
        }
        [HttpGet("cellphone/{cellphone}")]
        public async Task<IActionResult> GetCellphoneCustomer(string cellphone)
        {
            var customer = await _repocustomer.GetCustomersCellphoneAsync(cellphone);
            if(customer == null)
                return NotFound("Producto no encontrado");
            
            return Ok(customer);
        }

        [HttpPost]

        public async Task<IActionResult> Post(CustomerCreateDto customerDto)
        {
            var customerToCreate = new Customer();
            customerToCreate.Name = customerDto.Name;
            customerToCreate.Address = customerDto.Address;
            customerToCreate.Cellphone = customerDto.Cellphone;
            customerToCreate.Dateofcreation = DateTime.Now;
            _repocustomer.Add(customerToCreate);
            if(await _repocustomer.SaveAll())
                return Ok(customerToCreate);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerUpdateDto customerDto)
        {
            if(id != customerDto.Id)
                return BadRequest("El cliente no fue encontrado");
                
            var customerToUpdate = await _repocustomer.GetCustomersIdAsync(customerDto.Id);

            if (customerToUpdate == null)
                return BadRequest("EL id no existe");

            //customerToUpdate.Name = customerDto.Name;
            customerToUpdate.Address = customerDto.Address;
            customerToUpdate.Cellphone = customerDto.Cellphone;

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