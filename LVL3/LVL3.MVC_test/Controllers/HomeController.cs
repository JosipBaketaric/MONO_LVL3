using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVL3.Service;
using LVL3.Model;
using System.Threading.Tasks;

namespace LVL3.MVC_test.Controllers
{
    public class HomeController : Controller
    {
        private VehicleService service;

        public HomeController()
        {
            service = VehicleService.getInstance();
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<VehicleMake> makes = await service.ReadAllMakes();
            return View(makes);
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