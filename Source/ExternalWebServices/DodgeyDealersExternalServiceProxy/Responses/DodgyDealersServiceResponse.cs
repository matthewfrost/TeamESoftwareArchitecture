using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeyDealersExternalServiceProxy.Responses
{
    public class DodgyDealersServiceResponse<T>
    {
        public bool successful { get; set; }
        public T target { get; set; }
        public string message { get; set; }

    }
}
