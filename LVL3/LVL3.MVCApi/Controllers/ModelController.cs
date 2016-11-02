using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LVL3.MVCApi.Controllers
{
    [RoutePrefix("api/model")]
    public class ModelController : ApiController
    {

        protected IModelService ModelService;

        public ModelController(IModelService modelService)
        {
            this.ModelService = modelService;
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await ModelService.ReadAll();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }

}
