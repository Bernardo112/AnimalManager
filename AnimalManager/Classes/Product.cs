using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalManager.Components
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string NCM { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public Supplier Supplier { get; set; }
        public int Amount { get; set; }

        public Product(int id, string productName, string nCM, double salePrice, Supplier supplier)
        {
            Id = id;
            ProductName = productName;
            NCM = nCM;
            SalePrice = salePrice;
            Supplier = supplier;
        }

        public Product(int id, string productName, string nCM, double salePrice, double costPrice, Supplier supplier, int amount) : this(id, productName, nCM, salePrice, supplier)
        {
            CostPrice = costPrice;
            Amount = amount;
        }
    }
}

