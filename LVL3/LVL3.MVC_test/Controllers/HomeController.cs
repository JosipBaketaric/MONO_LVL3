using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVL3.Model;
using System.Threading.Tasks;
using LVL3.Common.ViewModels;
using LVL3.Service;

namespace LVL3.MVC_test.Controllers
{
    public class HomeController : Controller
    {
       
        protected VehicleService Service;
        public HomeController()
        {
            Service = VehicleService.GetService();
        }
        public async Task<ActionResult> Index()
        {
            
            return View( await Service.ReadAllMakes() );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}