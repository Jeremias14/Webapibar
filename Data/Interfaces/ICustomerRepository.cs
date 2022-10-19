using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBar.Models;

namespace WebApiBar.Data.Interfaces
{
    public interface ICustomerRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomersIdAsync(int id);
        Task<Customer> GetCustomersNameAsync(string name);
        Task<Customer> GetCustomersAddressAsync(string address);
        Task<Customer> GetCustomersCellphoneAsync(string cellphone);
    }
}