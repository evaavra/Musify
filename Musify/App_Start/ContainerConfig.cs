using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Musify.Interfaces;
using Musify.Models;
using Musify.Persistence;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Musify.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. 
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            // Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterContainerApi()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}