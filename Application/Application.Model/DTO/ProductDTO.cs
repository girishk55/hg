using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Model.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }

    }
}
