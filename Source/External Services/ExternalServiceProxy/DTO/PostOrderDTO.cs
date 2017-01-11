using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServiceProxy.DTO
{
    public class PostOrderDTO
    {
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
