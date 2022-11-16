using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class Supplier
    {
        public string CNPJ { get; set; }
        public string CorporateName { get; set; }
        public string TradingName { get; set; }
        public string Email { get; set; }

        //Address information
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Country { get; set; }

        public Supplier(string cNPJ, string corporateName, string tradingName, string email)
        {
            CNPJ = cNPJ;
            CorporateName = corporateName;
            TradingName = tradingName;
            Email = email;
        }

        public Supplier(string cNPJ, string corporateName, string tradingName, string email, string streetName, int houseNumber, string neighborhood, string city, string uF, string country) : this(cNPJ, corporateName, tradingName, email)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            Neighborhood = neighborhood;
            City = city;
            UF = uF;
            Country = country;
        }
    }
}

