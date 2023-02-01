using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Contract.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
