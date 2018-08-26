using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Managers
{
    public class SaleChannelManager
    {
        TPayDb _db = new TPayDb();

        public SaleCharter getCharter(int MerchantId, int OperatorId)
        {
            var _merchant = _db.Merchants.Find(MerchantId);
            var _operator = _merchant.Operators.ToList().Find(Oid => Oid.Id == OperatorId);
            if (_merchant != null && _operator != null)
            {
                return new SaleCharter
                {
                    operatorId = (int)OperatorId,
                    merchantId = (int)MerchantId,
                    operatorCountry = _operator.country,
                    merchantCountry = _merchant.country,
                    operatorName = _operator.name,
                    merchantName = _merchant.name
                };
            }
            return null;
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
        {

            var _mm = new MerchantManager();
            var elements = _mm.readDb();
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.name
                });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetOperatorsList(int id)
        {
            var selectList = new List<SelectListItem>();
            var _charters = readDb();
            var _om = new OperatorManager();
            var _operators = _om.readDb();
            var _mm = new MerchantManager();
            var _merchants = _mm.readDb();
            foreach (var item in _operators)
            {

                if (_charters.Find(m => (m.operatorId == item.Id) && (m.merchantId == id)) == null)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.name
                    });

                }

            }
            return selectList;
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

        public ManagerResultViewModel createRelationShip(int MerchantId, int OperatorId)
        {
            var _mm = new MerchantManager();
            var _om = new OperatorManager();
            var _merchat = _mm.GetMerchant(MerchantId);
            var _operator = _om.GetOperator(OperatorId);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _operator.country + " " + _merchat.country;
            _mrvm.name = _operator.name + " " + _merchat.name;
            _mrvm.Entity = "relationship between";
            _mrvm.OperationType = "create";
            if (_merchat != null && _operator != null)
            {
                
                _merchat.Operators.Add(_operator);
                _db.Merchants.Add(_merchat);
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "the relationship already exists or operator and/or merchant don't exist";
            return _mrvm;
        }

        public ManagerResultViewModel DeleteRelation(SaleCharter _sc)
        {
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _sc.operatorCountry + " and " + _sc.merchantCountry + " respectively";
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