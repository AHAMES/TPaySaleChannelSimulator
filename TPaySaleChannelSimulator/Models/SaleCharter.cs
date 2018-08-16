using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class SaleCharter
    {
        public string operatorName { get; set; }
        public string merchantName { get; set; }
        public string operatorCountry { get; set; }
        public string merchantCountry { get; set; }
        public int operatorId { get; set; }
        public int merchantId { get; set; }
    }
}