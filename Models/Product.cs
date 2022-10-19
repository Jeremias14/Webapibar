using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBar.Models
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public DateTime Dateofsale { get; set; }
       public decimal Price { get; set; }
       public bool State { get; set; }

    }
}