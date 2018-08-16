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

        public SaleCharter getCharter(int MerchantId , int OperatorId)
        {
            var _merchant = _db.Merchants.Find(MerchantId);
            var _operator = _merchant.Operators.ToList().Find(Oid=>Oid.Id==OperatorId);
            if (_merchant != null && _operator != null)
            {
                return new SaleCharter {
                    operatorId = (int)OperatorId,
                    merchantId = (int)MerchantId,
                    operatorCountry=_operator.country,
                    merchantCountry=_merchant.country,
                    operatorName=_operator.name,
                    merchantName=_merchant.name};
            }
            return null;
        }

        public List<SaleCharter> readDb()
        { 
            var _merchants = _db.Merchants.ToList();

            var _charter = new List<SaleCharter>();
            foreach (var item1 in _merchants)
            {
                var _operators = _db.Merchants
                      .Where(m => m.Id == item1.Id)
                      .SelectMany(m => m.Operators).ToList();

                foreach (var item in _operators)
                {
                    _charter.Add(new SaleCharter
                    {
                        merchantCountry = _db.Merchants.Find(item1.Id).country,
                        merchantName = _db.Merchants.Find(item1.Id).name,
                        merchantId = item1.Id,
                        operatorCountry = _db.Operators.Find(item.Id).country,
                        operatorName = _db.Operators.Find(item.Id).name,
                        operatorId = item.Id
                    });
                }
            }
            return _charter;
        }

        public ManagerResultViewModel DeleteRelation(SaleCharter _sc)
        {
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _sc.operatorCountry+" and "+_sc.merchantCountry+" respectively";
            _mrvm.name = _sc.operatorName + " and " + _sc.merchantName;
            _mrvm.Entity = "Operator and Merchant";
            _mrvm.OperationType = "deletion of relationshipbetween";
            if (_db.Operators.Find(_sc.operatorId) == null || _db.Merchants.Find(_sc.merchantId) == null)
            {
                _mrvm.isSuccessful = false;
                _mrvm.reason = "as one of them doens't exist or no relation";
                return (_mrvm);
            }
            _db.Merchants.Find(_sc.merchantId).Operators.Remove(_db.Operators.Find(_sc.operatorId));
            _db.SaveChanges();
            _mrvm.isSuccessful = true;
            return (_mrvm);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}