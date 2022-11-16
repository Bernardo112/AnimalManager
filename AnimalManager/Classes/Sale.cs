using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class Sale
    {
        public int Id { get; set; }
        public List<SaleProduct> SaleProducts { get; set; }
        public double TotalValue { get; set; }
        public DateTime Date { get; set; }

        public Sale(int id, List<SaleProduct> saleProducts, double totalValue, DateTime date)
        {
            Id = id;
            SaleProducts = saleProducts;
            foreach (SaleProduct product in saleProducts)
            {
                TotalValue = product.Product.SalePrice * product.Amount;
            }
            Date = date;
        }
    }
}
