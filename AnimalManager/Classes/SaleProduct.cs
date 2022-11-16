using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class SaleProduct
    {
        public Product Product { get; set; }
        public int Amount { get; set; } = 1;

        public SaleProduct(Product product, int amount)
        {
            Product = product;
            if (amount <= 0)
            {
                Amount = 1;
            }
            else
            {
                Amount = amount;
            }
        }
    }
}