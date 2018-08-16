using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Managers
{
    public class OperatorManager
    {
        TPayDb _db = new TPayDb();
        public List<Operator> readDb()
        {
            return _db.Operators.ToList();
        }
        public List<Operator> EntityExists(Operator op)
        {
            var _matchingOp = from r in _db.Operators
                              where r.name.ToLower().Equals(op.name.ToLower()) &&
                                    r.country.ToLower().Equals(op.country.ToLower())
                              select r;

            return _matchingOp.ToList();
        }
        public ManagerResultViewModel createOperator(Operator op)
        {
            var _matchingOp = EntityExists(op);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = op.country;
            _mrvm.name = op.name;
            _mrvm.Entity = "Operator";
            _mrvm.OperationType = "Creation";
            if (!_matchingOp.Any())
            {
                _db.Operators.Add(op);
                _db.SaveChanges();
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as it already exists";
            return _mrvm;
        }
        public ManagerResultViewModel EditOperator(Operator op)
        {
            var _matchingOp = EntityExists(op);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = op.country;
            _mrvm.name = op.name;
            _mrvm.Entity = "Operator";
            _mrvm.OperationType = "Editing";
            if (_matchingOp.Count == 1 && _matchingOp.ElementAt(0).Id == op.Id)
            {
                var query = from Op in _db.Operators
                            where Op.Id == op.Id
                            select Op;
                foreach (Operator Op in query)
                {
                    Op.country = op.country;
                    Op.description = op.description;
                    Op.name = op.name;
                    Op.isDown = op.isDown;
                }
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as another Operator of the same name and country exists";
            return _mrvm;
        }
        public ManagerResultViewModel DeleteOperator(int id)
        {
            var _matchingOp = _db.Operators.Find(id);
            var _mrvm = new ManagerResultViewModel();
            _mrvm.country = _matchingOp.country;
            _mrvm.name = _matchingOp.name;
            _mrvm.Entity = "Operator";
            _mrvm.OperationType = "deletion";
            if (_matchingOp!=null)
            {
                _db.Operators.Remove(_matchingOp);
                _db.SaveChanges();
                _mrvm.isSuccessful = true;
                return _mrvm;
            }
            _mrvm.isSuccessful = false;
            _mrvm.reason = "as the Operator does not exist";
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