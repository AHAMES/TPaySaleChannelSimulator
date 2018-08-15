using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class Operator
    {
        public string name { get; set; }
        public int Id { get; set; }
        public string country { get; set; }
        public bool isDown { get; set; }
        public string description { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }

    }

}