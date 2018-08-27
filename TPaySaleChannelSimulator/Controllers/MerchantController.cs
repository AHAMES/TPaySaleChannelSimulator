using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Managers;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Controllers
{
    public class MerchantController : Controller
    {
       MerchantManager _mm = new MerchantManager();
        // GET: Merchant
        public ActionResult Index()
        {
            return View(_mm.readDb());
        }

        // GET: Merchant/Details/5


        // GET: Merchant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Merchant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,country,isDown,description")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                var _mrvm = _mm.createMerchant(merchant);

                return View("OperationStatus", _mrvm);
            }

            return View(merchant);
        }

        // GET: Merchant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var merchant = _mm.GetMerchant((int)id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: Merchant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,country,isDown,description")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                var _mrvm = _mm.EditMerchant(merchant);
                return View("OperationStatus", _mrvm);
            }
            return View(merchant);
        }

        // GET: Merchant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = _mm.readDb().ElementAt(0);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: Merchant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            var _mrvm = _mm.DeleteMerchant(id);
            return View("OperationStatus", _mrvm);
        }
    }
}
