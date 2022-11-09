using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBar.Models;

namespace WebApiBar.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeesIdAsync(int id);
        Task<Employee> GetEmployeesNameAsync(string name);
        Task<Employee> GetEmployeesAddressAsync(string address);
        Task<Employee> GetEmployeesCellphoneAsync(string cellphone);
        Task<Employee> GetEmployeesDniAsync(string dni);
    }
}