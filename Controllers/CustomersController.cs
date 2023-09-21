using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mappercustomer;


        public CustomersController(ICustomerRepository repocustomer, IMapper mappercustomer)
        {
            _repocustomer = repocustomer;
            _mappercustomer = mappercustomer;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _repocustomer.GetCustomersAsync();
            var customerDto = _mappercustomer.Map<IEnumerable<Customer>>(customers);
            return Ok(customers);
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdCustomer(int id)
        {
            var customer = await _repocustomer.GetCustomersIdAsync(id);
            var customerDto = _mappercustomer.Map<Customer>(customer);
            if(customer == null)
                return NotFound("Cliente no encontrado"); 
            
            //var customerDto = new CustomerGetDto();
            //customerDto.Id = customer.Id;
            //customerDto.Name = customer.Name;
            //customerDto.Address = customer.Address;
            //customerDto.Cellphone = customer.Cellphone;
            
            return Ok(customerDto);
        }
        
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetNameCustomer(string name)
        {
            var customer = await _repocustomer.GetCustomersNameAsync(name);
            if(customer == null)
                return NotFound("Cliente no encontrado");
            
            return Ok(customer);
        }
        [HttpGet("cellphone/{cellphone}")]
        public async Task<IActionResult> GetCellphoneCustomer(string cellphone)
        {
            var customer = await _repocustomer.GetCustomersCellphoneAsync(cellphone);
            if(customer == null)
                return NotFound("Cliente no encontrado");
            
            return Ok(customer);
        }

        [HttpPost]

        public async Task<IActionResult> PostCustomer(CustomerPostDto customerDto)
        {
            //var customerToCreate = new Customer();
            //customerToCreate.Name = customerDto.Name;
            //customerToCreate.Address = customerDto.Address;
            //customerToCreate.Cellphone = customerDto.Cellphone;
            var customerToCreate = _mappercustomer.Map<Customer>(customerDto);
            _repocustomer.Add(customerToCreate);
            if(await _repocustomer.SaveAll())
                return Ok(customerToCreate);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerPutDto customerDto)
        {
            if(id != customerDto.Id)
                return BadRequest("El cliente no fue encontrado");
                
            var customerToUpdate = await _repocustomer.GetCustomersIdAsync(customerDto.Id);

            if (customerToUpdate == null)
                return BadRequest("EL id no existe");

            //customerToUpdate.Name = customerDto.Name;
            //customerToUpdate.Address = customerDto.Address;
            //customerToUpdate.Cellphone = customerDto.Cellphone;
            _mappercustomer.Map(customerDto, customerToUpdate);

            if(!await _repocustomer.SaveAll())
                return NoContent();
            
            return Ok(customerToUpdate);
        
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _repocustomer.GetCustomersIdAsync(id);

            if(customer == null)
                return NotFound("Cliente no encontrado");
            
            _repocustomer.Delete(customer);
            if(!await _repocustomer.SaveAll())
                return BadRequest("El cliente no fue encontrado");
            
            return Ok("Cliente borrado");

        }    
    }
}