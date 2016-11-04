using LVL3.Model.DomainModels;
using LVL3.Model.ViewModels;
using LVL3.Service.Common;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = AutoMapper.Mapper.Map< IEnumerable<VehicleMakeView> >( await MakeService.ReadAll() );
            //var response = await MakeService.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            var response = AutoMapper.Mapper.Map<VehicleMakeView>( await MakeService.Read(id));

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(VehicleMakeView vehicleMakeView)
        {
            
            if (vehicleMakeView.Name == null || vehicleMakeView.Abrv == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model is not complete. Please provide name and abrv");

            vehicleMakeView.VehicleMakeId = Guid.NewGuid();

            var response = await MakeService.Add( AutoMapper.Mapper.Map<VehicleMakeDomain>(vehicleMakeView) );              

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var maker = AutoMapper.Mapper.Map<VehicleMakeView>( await MakeService.Read(id) );

            if (maker.VehicleModel.Count != 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, 
                    "Maker has models bind to him. First delete all the models it is using.");

            var response = await MakeService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public async Task<HttpResponseMessage> Update(Guid id, VehicleMakeView vehicleMakeView)   
        {
            var toBeUpdated = await MakeService.Read(id);

            if(vehicleMakeView.Name != null)
                toBeUpdated.Name = vehicleMakeView.Name;
            if(vehicleMakeView.Abrv != null)
                toBeUpdated.Abrv = vehicleMakeView.Abrv;

            var response = await MakeService.Update(AutoMapper.Mapper.Map<VehicleMakeDomain>(toBeUpdated));

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
