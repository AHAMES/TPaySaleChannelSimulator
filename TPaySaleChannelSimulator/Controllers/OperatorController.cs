using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Models;
using TPaySaleChannelSimulator.Managers;
namespace TPaySaleChannelSimulator.Controllers
{
    public class OperatorController : Controller
    {
        private TPayDb db = new TPayDb();

        // GET: Operator
        public ActionResult Index()
        {
            var _om=new OperatorManager();

            return View(_om.readDb());
        }

        // GET: Operator/Details/5
        

        // GET: Operator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,country,isDown,description")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                var _om = new OperatorManager();
                var _mrvm = _om.createOperator(@operator);

                return View("OperationStatus", _mrvm);
            }

            return View(@operator);
        }

        // GET: Operator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operator @operator = db.Operators.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        // POST: Operator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,country,isDown,description")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                
                var _om = new OperatorManager();
                var _mrvm = _om.EditOperator(@operator);
                return View("OperationStatus", _mrvm);
            }
            return View(@operator);
        }

        // GET: Operator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _om = new OperatorManager();
            Operator @operator = _om.readDb().ElementAt(0);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        // POST: Operator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var _om = new OperatorManager();
            var _mrvm = _om.DeleteOperator(id);
            return View("OperationStatus", _mrvm);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
