using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace ESM.Infrastructure
{
    public class NinjectDependencyReslover : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyReslover(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            //tutaj wrzucamy wszystkie powiązania
        }
    }
}