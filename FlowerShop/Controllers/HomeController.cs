using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class HomeController : Controller
    {
        // Create the database. Name is found under Web.config at the bottom.
        private asp11Entities database = new asp11Entities();
        public ActionResult Index()

        //get data inbound model data
        {
            // Create List of flowers from the FLOWERs table in the database.
            // Create List of flowers from the FLOWERs table in the database.
            var allColors = database.COLORs.ToList();
            List<COLOR> flowers = new List<COLOR>();

            foreach (var color in allColors)
            {
                COLOR model = new COLOR();
                model.COLOR_NAME = color.COLOR_NAME;
                model.COLOR_ID = color.COLOR_ID;
                model.FLOWERs = database.FLOWERs.Where(a => a.COLOR_ID == color.COLOR_ID).ToList();
                flowers.Add(model);
            }

            // Pass filtered list of flowers to the view
            return View(flowers);
        }

        [HttpPost]
        public ActionResult Index(SearchMyFlower searchMyFlower)
        {
            // Get Data from inbound model
            int uFlower = -1;
            string uSize = "";
            int uFrom = 0;
            int uTo = 0;

            if (searchMyFlower.fromPrice > 0)
            {
                uFrom = searchMyFlower.fromPrice;
            }

            if (searchMyFlower.toPrice > 0)
            {
                uTo = searchMyFlower.toPrice;
            }

            // Create List of flowers from the FLOWERs table in the database.
            var allColors = database.COLORs.ToList();
            List<COLOR> colors = new List<COLOR>();

                foreach (var color in allColors)
                {
                    COLOR model = new COLOR();
                    model.COLOR_NAME = color.COLOR_NAME;
                    model.COLOR_ID = color.COLOR_ID;

                    var allFlowers = from c in database.FLOWERs
                                     where c.COLOR_ID == color.COLOR_ID
                                     where (c.COLOR_ID.Equals(uFlower) || string.IsNullOrEmpty(uSize))
                                     where (c.FLOWER_SIZE.Equals(uSize) || string.IsNullOrEmpty(uSize))
                                     where (c.FLOWER_PRICE >= uFrom || uFrom == 0)
                                     where (c.FLOWER_PRICE <= uTo || uTo == 0)
                                     select c;

                    model.FLOWERs = allFlowers.ToList();

                    colors.Add(model);
                }
            //}
            // Pass filtered list of flowers to the view
            return View(colors);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Legal()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUser(AddUser model)
        {
            return Json(model);
        }

        public ActionResult Feature(int id) {

            FLOWER flower = database.FLOWERs.Find(id);

            if (flower == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Shared/_Feature.cshtml", flower);
        }

    }
}