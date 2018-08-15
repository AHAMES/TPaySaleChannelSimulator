using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class OperatorMerchantViewModel
    {
        public List<Operator> Operators{ get; set; }
        public List<Merchant> Merchants { get; set; }
    }
}