using LVL3.Model.Common.IView;
using LVL3.Service.Common;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LVL3.MVCApi.Controllers
{
    [RoutePrefix("api/make")]
    public class MakeController : ApiController
    {
        protected IMakeService MakeService;
        protected IVehicleMakeView VehicleMake;

        public MakeController(IMakeService makeService, IVehicleMakeView vehicleMake)
        {
            this.MakeService = makeService;
            this.VehicleMake = vehicleMake;
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var makes = await MakeService.ReadAll();

            //var json = new JavaScriptSerializer().Serialize(makes);

            return Request.CreateResponse(HttpStatusCode.OK, makes);
        }


    }
}
