using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPaySaleChannelSimulator.Models;

namespace TPaySaleChannelSimulator.Controllers
{
    public class MerchantController : Controller
    {
        // GET: Merchant
        public ActionResult Index()
        {
            var merchants = new List<Merchant>
            {
                new Merchant
                {
                    name="Anghamy",
                    Id=1,
                    country="Egypt"
                },
                new Merchant
                {
                    name="Shahed",
                    Id=2,
                    country="KSA"
                },
                new Merchant
                {
                    name="SoundCloud",
                    Id=3,
                    country="UK"
                },
                new Merchant
                {
                    name="Spotify",
                    Id=4,
                    country="US"
                }
            };
            return View(merchants);
        }
    }
}