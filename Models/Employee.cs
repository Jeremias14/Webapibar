using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBar.Models
{
    public class Employee
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public string Cellphone { get; set; }
       public string Dni { get; set; }
       public DateTime Dateofcreation { get; set; }
    }
}