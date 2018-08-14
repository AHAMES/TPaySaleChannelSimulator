using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Controllers
{
    public class OperatorController : Controller
    {
        // GET: Operator
        public ActionResult Index()
        {
            var operators = new List<Operator>
            {
                new Operator
                {
                    name="Vodafone",
                    Id=1
                },
                new Operator
                {
                    name="Etisalat",
                    Id=2
                },
                new Operator
                {
                    name="Orange",
                    Id=3
                },
                new Operator
                {
                    name="WE",
                    Id=4
                }
            };
            return View(operators);
        }
    }
}