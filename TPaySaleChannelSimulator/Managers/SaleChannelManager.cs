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
            var _operator = _db.Operators.Find(OperatorId);

            if (_merchant != null && _operator != null)
            {
                var channel = from sc in _db.saleChannel
                              where sc.merchantId == MerchantId && sc.operatorId == OperatorId
                              select sc;
                if (channel.Any())
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
        public IEnumerable<SelectListItem> GetMerchantsList()
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

                if (_charters.Find(m => (m.operatorId == item.Id) && (m.merchantId == id)) != null)
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

        public IEnumerable<SelectListItem> GetMerchantsList(int id)
        {
            var selectList = new List<SelectListItem>();
            var _charters = readDb();
            var _om = new OperatorManager();
            var _operators = _om.readDb();
            var _mm = new MerchantManager();
            var _merchants = _mm.readDb();
            foreach (var item in _merchants)
            {

                if (_charters.Find(m => (m.operatorId == id) && (m.merchantId == item.Id)) != null)
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

        public IEnumerable<SelectListItem> GetOperatorsList()
        {

            var _mm = new OperatorManager();
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


        public List<SaleCharter> readDb()
        {
            var _saleChannel = _db.saleChannel.ToList();
            var _charter = new List<SaleCharter>();
            foreach (var sc in _saleChannel)
            {
                var merchant = _db.Merchants.Find(sc.merchantId);
                var operat0r = _db.Operators.Find(sc.operatorId);
                _charter.Add(new SaleCharter
                {

                    merchantCountry = merchant.country,
                    merchantName = merchant.name,
                    merchantId = merchant.Id,
                    operatorCountry = operat0r.country,
                    operatorName = operat0r.name,
                    operatorId = operat0r.Id
                });

            }
            return _charter;
        }

        public ManagerResultViewModel createRelationShip(int MerchantId, int OperatorId)
        {
            var _mm = new MerchantManager();
            var _om = new OperatorManager();
            var _merchat = _mm.GetMerchant(MerchantId);//gets merchant object 
            var _operator = _om.GetOperator(OperatorId);//gets operator object 
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _operator.country + " and " + _merchat.country+" respectively";
            _mrvm.name = _operator.name + " and " + _merchat.name;
            _mrvm.Entity = "Operator and Merchant";
            _mrvm.OperationType = "creation of the relationship";
            if (_merchat != null && _operator != null)
            {
                var channel = from sc in _db.saleChannel
                              where sc.merchantId == MerchantId && sc.operatorId == OperatorId
                              select sc;
                if (!channel.Any())
                {
                    _db.saleChannel.Add(new SaleChannel { merchantId = MerchantId, operatorId = OperatorId });
                    _mrvm.isSuccessful = true;
                    _db.SaveChanges();
                    return _mrvm;
                }
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

            var _saleChannel = _db.saleChannel;
            var channel = from sc in _saleChannel
                          where sc.merchantId == _sc.merchantId && sc.operatorId == _sc.operatorId
                          select sc;
            if (!channel.Any())
            {
                _mrvm.isSuccessful = false;
                _mrvm.reason = "as one of them doens't exist or no relation";
                return (_mrvm);
            }

            _db.saleChannel.Remove(channel.ToList().First());
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