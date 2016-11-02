using LVL3.Model.Common.IView;
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
        protected IVehicleModelView ModelView;

        public ModelController(IModelService modelService, IVehicleModelView modelView)
        {
            this.ModelService = modelService;
            this.ModelView = modelView;
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await ModelService.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            var response = await ModelService.Read(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = await ModelService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(Guid MakeId, string name, string abrv)
        {
            ModelView.VehicleModelId = Guid.NewGuid();
            ModelView.Name = name;
            ModelView.Abrv = abrv;
            ModelView.VehicleMakeId = MakeId;

            var response = await ModelService.Add(ModelView);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("update")]
        public async Task<HttpResponseMessage> Update(Guid id, Guid MakeId, string name, string abrv)
        {
            throw new NotImplementedException();    //Works with delete then add new. Update not working
        }


    }

}
