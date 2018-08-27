using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Managers
{
    public class MerchantManager
    {
        TPayDb _db = new TPayDb();
        public List<Merchant> readDb()
        {
            return _db.Merchants.ToList();
        }
        public Merchant GetMerchant(int id)
        {
            return _db.Merchants.ToList().Find(m => m.Id == id);
        }
        public List<Merchant> EntityExists(Merchant op)
        {
            var _matchingOp = from r in _db.Merchants
                              where r.name.ToLower().Equals(op.name.ToLower()) &&
                                    r.country.ToLower().Equals(op.country.ToLower())
                              select r;

            return _matchingOp.ToList();
        }
        public ManagerResultViewModel createMerchant(Merchant op)
        {
            var _matchingOp = EntityExists(op);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = op.country;
            _mrvm.name = op.name;
            _mrvm.Entity = "Merchant";
            _mrvm.OperationType = "Creation";
            if (!_matchingOp.Any())
            {
                _db.Merchants.Add(op);
                _db.SaveChanges();
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as it already exists";
            return _mrvm;
        }
        public ManagerResultViewModel EditMerchant(Merchant op)
        {

            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = op.country;
            _mrvm.name = op.name;
            _mrvm.Entity = "Merchant";
            _mrvm.OperationType = "Editing";
            var query = from Op in _db.Merchants
                        where Op.Id == op.Id
                        select Op;
            if (query.Any())
            {

                var Op = _db.Merchants.Find(query.ToList().First().Id);
                if (Op.name != op.name || Op.country != op.country)
                {
                    Op.country = op.country;
                    Op.description = op.description;
                    Op.name = op.name;
                    Op.isDown = op.isDown;
                    _db.Entry(Op).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();


                    _mrvm.isSuccessful = true;
                    return _mrvm;
                }
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as another Merchant of the same name and country exists";
            return _mrvm;
        }
        public ManagerResultViewModel DeleteMerchant(int id)
        {
            var _matchingOp = _db.Merchants.Find(id);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _matchingOp.country;
            _mrvm.name = _matchingOp.name;
            _mrvm.Entity = "Merchant";
            _mrvm.OperationType = "deletion";
            if (_matchingOp != null)
            {
                _db.Merchants.Remove(_matchingOp);
                _db.SaveChanges();
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as the Merchant does not exist";
            return _mrvm;
        }
        protected void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}