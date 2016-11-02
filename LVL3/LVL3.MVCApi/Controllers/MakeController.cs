using LVL3.Model.Common.IView;
using LVL3.Model.DomainModels;
using LVL3.Model.ViewModels;
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

        [HttpGet]
        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await MakeService.ReadAll();

            //var json = new JavaScriptSerializer().Serialize(makes);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            var response = await MakeService.Read(id);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(string name, string abrv)
        {
            MakeView.Name = name;
            MakeView.Abrv = abrv;
            MakeView.VehicleMakeId = Guid.NewGuid();
            var response = await MakeService.Add( MakeView );          

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {           
            var response = await MakeService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public async Task<HttpResponseMessage> Update(Guid id, VehicleMakeView mv)   
        {
            var toBeUpdated = await MakeService.Read(id);

            if(mv.Name != null)
                toBeUpdated.Name = mv.Name;
            if(mv.Abrv != null)
                toBeUpdated.Abrv = mv.Abrv;

            var response = await MakeService.Update(AutoMapper.Mapper.Map<VehicleMakeDomain>(toBeUpdated));
            //await MakeService.Delete(id);

            //MakeView.VehicleMakeId = id;
            //MakeView.Name = name;                     //Works with delete then add new. Update not working
            //MakeView.Abrv = abrv;

            //var result = await MakeService.Add(MakeView);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
