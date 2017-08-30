using LakewoodScoop.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodScoop.Scraper;

namespace LakewoodScoop.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new IndexViewModel();
            vm.Posts = Scraper.Scraper.GetTopScoops();
            return View(vm);
        }
        
    }
}