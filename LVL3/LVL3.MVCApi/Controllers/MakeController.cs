using LVL3.Model.Common.IView;
using LVL3.Service.Common;
using System;
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
        protected IVehicleMakeView MakeView;

        public MakeController(IMakeService makeService, IVehicleMakeView makeView)
        {
            this.MakeService = makeService;
            this.MakeView = makeView;
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await MakeService.ReadAll();

            //var json = new JavaScriptSerializer().Serialize(makes);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(string name, string abrv)
        {
            MakeView.Name = name;
            MakeView.Abrv = abrv;
            MakeView.VehicleMakeId = Guid.NewGuid();
            var response = await MakeService.Add( MakeView );          

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}
