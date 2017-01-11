using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazzasBazaarExternalServiceProxyWCF.DTO
{
    public class OrderDTO
    {
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public int Id { get; set; }
        public string ProductEan { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime When { get; set; }
    }
}
