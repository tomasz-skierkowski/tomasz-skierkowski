using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [DebuggerDisplay("{Product.Name}")]
    public class ProductQuantity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ProductQuantity(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;    
        }
    }
}
