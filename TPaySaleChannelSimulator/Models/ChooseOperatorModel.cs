using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Managers;

namespace TPaySaleChannelSimulator.Models
{
    public class ChooseOperatorModel
    {
        
        public Merchant merchant { get; set; }
        public IEnumerable<SelectListItem> Operators { get; set; }
        public ChooseOperatorModel(int id)
        {
            var m = new MerchantManager();
            merchant = m.GetMerchant(id);
            Operators = null;
        }
    }
}