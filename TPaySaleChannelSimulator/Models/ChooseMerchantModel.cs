using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPaySaleChannelSimulator.Models
{
    public class ChooseMerchantModel
    {
        public IEnumerable<SelectListItem> Merchants { get; set; }
    }
}