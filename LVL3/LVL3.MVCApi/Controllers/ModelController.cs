﻿using LVL3.Model.DomainModels;
using LVL3.MVCApi.ViewModels;
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
        protected IMakeService MakeService;

        public ModelController(IModelService modelService, IMakeService makeService)
        {
            this.ModelService = modelService;
            this.MakeService = makeService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var makers = await MakeService.ReadAll();
                var response = AutoMapper.Mapper.Map<IEnumerable<VehicleModelView>>(await ModelService.ReadAll());

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
                var response = AutoMapper.Mapper.Map<VehicleModelView>(await ModelService.Read(id));

                if(response == null)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Bad id.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get data. Database error.");
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = await ModelService.Delete(id);

                if(response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete model.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete data. Database error.");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add(VehicleModelView vehicleModelView)
        {
            try
            {
                if (vehicleModelView.Name == null || vehicleModelView.Abrv == null || vehicleModelView.VehicleMakeId == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model is not complete. Please provide name, abrv and make id");

                var fMakerExist = await MakeService.Read(vehicleModelView.VehicleMakeId);

                if (fMakerExist == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid VehicleMakeId");

                vehicleModelView.VehicleModelId = Guid.NewGuid();

                var response = await ModelService.Add(AutoMapper.Mapper.Map<VehicleModelDomain>(vehicleModelView));

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't add model. Database error.");
            }

        }

        [HttpPut]
        [Route("update")]
        public async Task<HttpResponseMessage> Update(VehicleModelView vehicleModelView)
        {
            try
            {
                var toBeUpdated = await ModelService.Read(vehicleModelView.VehicleModelId);

                if (vehicleModelView.Name != null)
                    toBeUpdated.Name = vehicleModelView.Name;
                if (vehicleModelView.Abrv != null)
                    toBeUpdated.Abrv = vehicleModelView.Abrv;

                var response = await ModelService.Update(AutoMapper.Mapper.Map<VehicleModelDomain>(toBeUpdated));

                if(response == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't update model.");

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't update model. Database error.");
            }
           
        }


    }

}
