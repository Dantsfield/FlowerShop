using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class SearchByFlowerController : Controller
    {
        private asp11Entities db = new asp11Entities();

        // GET: SearchByFlower
        public ActionResult Index()
        {
            SearchMyFlower model = new SearchMyFlower();

            model.AllFlowerOptions = db.COLORs.ToList().Select(s => new SelectListItem
            {
                Text = s.COLOR_NAME.ToString(),
                Value = s.COLOR_ID.ToString()
            });

            return PartialView("~/Views/Shared/_FilterProducts.cshtml", model);
        }
        [HttpPost]

        public ActionResult Index(SearchMyFlower model)
        {

            if (String.IsNullOrEmpty(model.FlowerSelected) &&
                String.IsNullOrEmpty(model.flowerSize) &&
                model.toPrice == 0 &&
                model.fromPrice == 0)
            {
                ModelState.AddModelError("", "Please Check Your Filter Criteria");
            }
            else
            {

            }

            if (model.toPrice > 0 && model.fromPrice > 0) 
            { 
                if (model.fromPrice > model.toPrice)
                {
                    ModelState.AddModelError("", "Please Check the Price Range");
                }
            }

            model.AllFlowerOptions = db.COLORs.ToList().Select(s => new SelectListItem
            {
                Text = s.COLOR_NAME.ToString(),
                Value = s.COLOR_ID.ToString()
            });

            return PartialView("~/Views/Shared/_FilterProducts.cshtml", model);
        }

        [HttpPost]

        public ActionResult SearchBox(SearchMyFlower model)
        {
            if (String.IsNullOrEmpty(model.SearchBox)&&
                String.IsNullOrEmpty(model.FlowerSelected) &&
                String.IsNullOrEmpty(model.flowerSize) &&
                model.toPrice == 0 &&
                model.fromPrice == 0)
            {
            ModelState.AddModelError("", "Please Enter Search Term");
            }

            return PartialView("~/Views/Shared/_Search.cshtml", model);
        }

        public ActionResult SearchBox()
        {
            return PartialView("~/Views/Shared/_Search.cshtml");
        }
    }
}