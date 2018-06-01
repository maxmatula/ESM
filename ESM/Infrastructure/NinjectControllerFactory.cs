using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using ESM.Services;
using ESM.DAL;
using System.Web.Routing;

namespace ESM.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext reqCtx, Type controllerType)
        {
            return kernel.Get(controllerType) as IController;
        }

        private void AddBindings()
        {
            kernel.Bind<IAgreementsService>().To<AgreementsService>();
            kernel.Bind<ICertyficationsService>().To<CertyficationsService>();
            kernel.Bind<ICompaniesService>().To<CompaniesService>();
            kernel.Bind<IEmployeesService>().To<EmployeesService>();
            kernel.Bind<IEventsService>().To<EventsService>();
            kernel.Bind<IRecruitmentDocumentsService>().To<RecruitmentDocumentsService>();
            kernel.Bind<IDirectoriesService>().To<DirectoriesService>();
            kernel.Bind<ESMDbContext>().ToSelf();
        }
    }
}