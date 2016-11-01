using LVL3.Service.Common;
using Ninject;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LVL3.MVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
