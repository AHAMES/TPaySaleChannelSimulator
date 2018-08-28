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

        //public ActionResult ChooseMerchant()
        //{
        //    var x = new ChooseMerchantModel();
        //    x.Merchants = _scm.GetSelectListItems();
        //    return View(x);
        //}


        public ActionResult CreateRelationShip()
        {
            var model = new ChooseRelationshipViewModel();
            model.Merchants = _scm.GetMerchantsList();
            model.Operators = _scm.GetOperatorsList();
            model.SaleChannels = _scm.readDb();
            return View("ChooseRelationship",model);
        }

        [HttpPost]
        public JsonResult FindUsedOperators(string merchantID)
        {

            var OperatorList = _scm.GetOperatorsList(int.Parse(merchantID));
            return Json(OperatorList);
        }
        [HttpPost]
        public ActionResult CreateRelation(FormCollection form)
        {
            int merchantId = int.Parse(form["MerchantSelected"].ToString());
            int operatorId = int.Parse(form["OperatorSelected"].ToString());

            var situation = _scm.createRelationShip(merchantId, operatorId);
            return View("OperationStatus", situation);
        }

        //[HttpPost]
        //public ActionResult ChooseOperator(FormCollection form)
        //{
        //    int id = int.Parse(form["MerchantSelected"].ToString());
        //    var x = new ChooseOperatorModel(id);
        //    x.Operators = _scm.GetOperatorsList(id);
        //    return View(x);
        //}

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