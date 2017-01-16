using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhansKwikimartExternalServiceProxy.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int RangeId { get; set; }
        public string RangeName { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
    }
}
