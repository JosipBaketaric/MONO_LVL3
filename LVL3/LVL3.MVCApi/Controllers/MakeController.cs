using LVL3.Model.DomainModels;
using LVL3.MVCApi.ViewModels;
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
            try
            {
                var response = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeView>>(await MakeService.ReadAll());

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data. Database error.");
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var response = AutoMapper.Mapper.Map<VehicleMakeView>(await MakeService.Read(id));

                if(response == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad id.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data. Database error.");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(VehicleMakeView vehicleMakeView)
        {
            try
            {
                if (vehicleMakeView.Name == null || vehicleMakeView.Abrv == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model is not complete. Please provide name and abrv");

                vehicleMakeView.VehicleMakeId = Guid.NewGuid();

                var response = await MakeService.Add(AutoMapper.Mapper.Map<VehicleMakeDomain>(vehicleMakeView));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't add data. Database error.");
            }
            
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var maker = AutoMapper.Mapper.Map<VehicleMakeView>(await MakeService.Read(id));

                if (maker.VehicleModel.Count != 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable,
                        "Maker has models bind to him. First delete all the models it is using.");

                if(maker == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad id.");

                var response = await MakeService.Delete(id);

                if(response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldn't delete maker.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete data. Database error.");
            }

        }

        [HttpPut]
        [Route("update/")]
        public async Task<HttpResponseMessage> Update(VehicleMakeView vehicleMakeView)   
        {
            try
            {
                var toBeUpdated = await MakeService.Read(vehicleMakeView.VehicleMakeId);

                if(toBeUpdated == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Model not found");

                if (vehicleMakeView.Name != null)
                    toBeUpdated.Name = vehicleMakeView.Name;
                if (vehicleMakeView.Abrv != null)
                    toBeUpdated.Abrv = vehicleMakeView.Abrv;

                var response = await MakeService.Update(AutoMapper.Mapper.Map<VehicleMakeDomain>(toBeUpdated));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't update data. Database error.");
            }

        }

    }
}
