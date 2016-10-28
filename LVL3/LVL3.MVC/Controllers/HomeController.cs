using LVL3.Service.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LVL3.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IVehicleService Service;
        public HomeController(IVehicleService service)
        {
            Service = service;
        }
        public async Task<ActionResult> Index()
        {          
            var AllMakes = await Service.ReadAllMakes();
            ViewBag.Title = "Home Page";
            return View(AllMakes);
        }
    }
}
