using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class ManagerResultViewModel
    {
        public string name { get; set; }
        public string country { get; set; }
        public bool isSuccessful { get; set; }
        public string OperationType { get; set; }
        public string Entity { get; set; }
        public string reason { get; set; }
    }
}