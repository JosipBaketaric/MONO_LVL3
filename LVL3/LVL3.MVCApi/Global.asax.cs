using AutoMapper;
using LVL3.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LVL3.MVCApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            Database.SetInitializer<VehicleContext>(new VehicleInitializer());

            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                    typeof(LVL3.DependencyResolver.AutoMapperConfig.MappingConfig),
                    typeof(LVL3.MVCApi.AutoMapperConfig.Mapping)
                    })
                );

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
