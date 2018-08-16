using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Managers;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Controllers
{
    public class SaleChannelController : Controller
    {
        SaleChannelManager _scm = new SaleChannelManager();
        //GET: SaleChannel
        public ActionResult Index()
        {
            return View(_scm.readDb());
        }
        // GET: Operator/Delete/5
        public ActionResult Delete(int? Mid, int? Oid)
        {
            if (Mid == null || Oid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var charter = _scm.getCharter((int)Mid, (int)Oid);
            if (charter == null)
            {
                return HttpNotFound();
            }
            return View(charter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SaleCharter sc)
        {
            var _mrvm = _scm.DeleteRelation(sc);
            return View("OperationStatus", _mrvm);
        }
    }

}