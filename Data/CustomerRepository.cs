using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiBar.Data;
using WebApiBar.Models;
using WebApiBar.Data.Interfaces;

namespace WebApiBar.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
           _context = context;
        }
        public void Add<T>(T entity) where T : class
        { 
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<Customer> GetCustomersAddressAsync(string address)
        {
            var customer= await _context.customers.FirstOrDefaultAsync(u => u.Address == address);
           return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
           var customers = await _context.customers.ToListAsync();
           return customers;
        }


        public async Task<Customer> GetCustomersCellphoneAsync(string cellphone)
        {
            var customer= await _context.customers.FirstOrDefaultAsync(u => u.Cellphone == cellphone);
           return customer;
        }

        public async Task<Customer> GetCustomersIdAsync(int id)
        {
           var customer= await _context.customers.FirstOrDefaultAsync(u => u.Id == id);
           return customer;
        }


        public async Task<Customer> GetCustomersNameAsync(string name)
        {
           var customer=await _context.customers.FirstOrDefaultAsync(u => u.Name == name );
           return customer;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}
