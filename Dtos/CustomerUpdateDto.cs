using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBar.Dtos
{
    public class CustomerPutDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        
    }
}