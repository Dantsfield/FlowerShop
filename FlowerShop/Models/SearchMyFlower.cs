using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Models
{
    public class SearchMyFlower
    {
        public string FlowerSelected { get; set; }

        public string SearchBox { get; set; }

        public int fromPrice { get; set; }

        public int toPrice { get; set; }

        public string flowerSize { get; set; }
        public IEnumerable<SelectListItem> AllFlowerOptions { get; set; }
    }
}