using Application.API.Controllers;
using Application.Common.Contracts;
using Application.Common.Implementations;
using Application.DAL.Contracts;
using Application.DAL.Implementations;
using Application.Repository;
using Application.Service.Contracts;
using Application.Service.Implementations;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;

namespace Application.API.CastleDI
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                        Component.For<ILogService>()
                            .ImplementedBy<LogService>()
                            .LifeStyle.PerWebRequest,

                        Component.For<IDatabaseFactory>()
                            .ImplementedBy<DatabaseFactory>()
                            .LifeStyle.PerWebRequest,

                        Component.For<IUnitOfWork>()
                            .ImplementedBy<UnitOfWork>()
                            .LifeStyle.PerWebRequest,

                        AllTypes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                        AllTypes.FromAssemblyNamed("Application.Service")
                            .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

                        AllTypes.FromAssemblyNamed("Application.Repository")
                            .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
                        );
        }

    }
}