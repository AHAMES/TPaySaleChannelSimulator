using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPaySaleChannelSimulator.Models
{
    public class ChooseRelationshipViewModel
    {
        public IEnumerable<SelectListItem> Merchants { get; set; }
        public IEnumerable<SelectListItem> Operators { get; set; }
        public List<SaleCharter> SaleChannels { get; set; }
    }
}