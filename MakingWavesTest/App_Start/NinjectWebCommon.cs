using MakingWavesTest.Repository;
using MakingWavesTest.Service.Color;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakingWavesTest.App_Start
{
    public class NinjectWebCommon : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectWebCommon()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IColorService>().To<ColorService>();
            kernel.Bind<IColorRepository>().To<ColorRepository>(); 
        }
    }
}