using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiBar.Data.Interfaces;
using WebApiBar.Models;

namespace WebApiBar.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
         
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
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

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
           var employees = await _context.employees.ToListAsync();
           return employees;
        }
        public async Task<Employee> GetEmployeesIdAsync(int id)
        {
            var employee= await _context.employees.FirstOrDefaultAsync(u => u.Id == id);
           return employee;
        }
        public async Task<Employee> GetEmployeesNameAsync(string name)
        {
           var employee= await _context.employees.FirstOrDefaultAsync(u => u.Name == name );
           return employee;
        }
        public async Task<Employee> GetEmployeesAddressAsync(string address)
        {
           var employee= await _context.employees.FirstOrDefaultAsync(u => u.Address == address);
           return employee;
        }
        public async Task<Employee> GetEmployeesCellphoneAsync(string cellphone)
        {
           var employee = await _context.employees.FirstOrDefaultAsync(u => u.Cellphone == cellphone);
           return employee;
        }
        public async Task<Employee> GetEmployeesDniAsync(string dni)
        {
           var employee= await _context.employees.FirstOrDefaultAsync(u => u.Dni == dni);
           return employee;
        }
        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}