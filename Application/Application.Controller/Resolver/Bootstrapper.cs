using Autofac;
using System.Web.Http;
using Application.Controller.Log;
using Application.DAL;
using Application.Model;
using Application.Manager;
using Application.Service;
using Application.Repository;

namespace Application.Controller.Resolver
{
    internal class Bootstrapper
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
                new ResolveDependency(RegisterServices(builder))
            );
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(WebApiApplication).Assembly).PropertiesAutowired();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ProductManager>().As<IProductManager>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerDependency();      

            return
                builder.Build();
        }
    }
}