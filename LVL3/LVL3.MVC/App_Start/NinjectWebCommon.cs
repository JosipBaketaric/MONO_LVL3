[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LVL3.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LVL3.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace LVL3.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using LVL3.Model.Common;
    using System.Collections.Generic;
    using Service;
    using Service.Common;
    using Model.ViewModels;
    using Repository.Common;
    using Repository.Repositorys;
    using Model;
    using DAL;
    using System.Linq;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPatterns = settings.ExtensionSearchPatterns.Union(new string[] { "LVL3.*.dll" }).ToArray();
            var kernel = new StandardKernel(settings);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IVehicleModelViewModel>().To<VehicleModelView>();
            kernel.Bind<IVehicleMakeViewModel>().To<VehicleMakeView>();

            kernel.Bind<IVehicleMake>().To<VehicleMake>();
            kernel.Bind<IVehicleModel>().To<VehicleModel>();

            kernel.Bind<IEnumerable<VehicleModelView>>().To<IEnumerable<VehicleModelView>>();
            kernel.Bind<IEnumerable<VehicleMakeView>>().To<IEnumerable<VehicleMakeView>>();

            kernel.Bind<IVehicleService>().To<VehicleService>();

            kernel.Bind<IMakeRepository>().To<MakeRepository>();
            kernel.Bind<IModelRepository>().To<ModelRepository>();
            kernel.Bind<IRepository>().To<Repository>();

        }
    }
}
