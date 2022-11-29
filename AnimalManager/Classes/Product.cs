using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string NCM { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public int Amount { get; set; }

        public Product(int id, string productName, string nCM, double salePrice)
        {
            Id = id;
            ProductName = productName;
            NCM = nCM;
            SalePrice = salePrice;
        }

        public Product(int id, string productName, string brandName, string nCM, double salePrice, double costPrice, int amount)
        {
            Id = id;
            ProductName = productName;
            BrandName = brandName;
            NCM = nCM;
            SalePrice = salePrice;
            CostPrice = costPrice;
            Amount = amount;
        }
    }
}

