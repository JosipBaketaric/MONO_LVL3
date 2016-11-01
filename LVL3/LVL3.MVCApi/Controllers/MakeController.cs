using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

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

        [HttpGet, Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var makes = await MakeService.ReadAll();

            //var json = new JavaScriptSerializer().Serialize(makes);

            return Request.CreateResponse(HttpStatusCode.OK, makes);
        }

    }
}
