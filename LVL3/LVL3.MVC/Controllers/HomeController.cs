using LVL3.DependencyResolver;
using LVL3.Service.Common;
using Ninject;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LVL3.MVC.Controllers
{
    public class HomeController : Controller
    {
        //IKernel kernel = new StandardKernel(new TopLayer());
        IMakeService MakeService;
        public HomeController(IMakeService makeService)
        {
            MakeService = makeService;
        }
        public async  Task<ActionResult> Index()
        {
            
            return View(await MakeService.ReadAll());
        }
    }
}
