using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using ESM.Services;
using ESM.DAL;

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
            kernel.Bind<ICompaniesService>().To<CompaniesService>();
            kernel.Bind<IEmployeesService>().To<EmployeesService>();
            kernel.Bind<IDirectoriesService>().To<DirectoriesService>();
            kernel.Bind<IAgreementsService>().To<AgreementsService>();
            kernel.Bind<ICertyficationsService>().To<CertyficationsService>();
            kernel.Bind<ESMDbContext>().ToSelf();
        }
    }
}