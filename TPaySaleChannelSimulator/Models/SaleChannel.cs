using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class SaleChannel
    {
        
        public int ID { get; set; }
        public int OperatorID { get; set; }
        public int MerchantID { get; set; }
    }
}