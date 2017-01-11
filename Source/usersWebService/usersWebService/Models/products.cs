using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace usersWebService.Models
{
    public class products
    {
        public int productID { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public int categoryID { get; set; }

        public string categoryName { get; set; }

        public int brandID { get; set; }

        public double minPrice { get; set; }

        public double maxPrice { get; set; }
    }
}