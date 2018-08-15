using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Managers
{
    public class SaleChannelManager
    {
        TPayDb _db = new TPayDb();
        public List<SaleCharter> readDb()
        {
            var _chanel = _db.OperatorMerchants.ToList();
            var _charter = new List<SaleCharter>();
            foreach (var item in _chanel)
            {
                _charter.Add(new SaleCharter
                {
                    merchantCountry = _db.Merchants.Find(item.ID).country,
                    merchantName = _db.Merchants.Find(item.ID).name,
                    operatorCountry = _db.Operators.Find(item.ID).country,
                    operatorName = _db.Operators.Find(item.ID).name
                });
            }
            return _charter;
        }
    }
}