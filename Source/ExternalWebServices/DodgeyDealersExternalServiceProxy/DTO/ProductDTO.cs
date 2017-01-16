﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DodgeyDealersExternalServiceProxy.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Ean { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpectedRestock { get; set; }
    }
}