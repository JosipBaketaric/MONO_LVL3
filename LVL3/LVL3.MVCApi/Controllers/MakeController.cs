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

        public MakeController(IMakeService makeService)
        {
            this.MakeService = makeService;
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await MakeService.ReadAll();

            //var json = new JavaScriptSerializer().Serialize(makes);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}
