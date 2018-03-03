using Lab4WebApplication.Data;
using Lab4WebApplication.Repositories;
using Lab4WebApplication.Services;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Lab4WebApplication.Models;

namespace Lab4WebApplication.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IPetRepository, PetRepository>(Lifestyle.Scoped);
            container.Register<IPetService, PetService>(Lifestyle.Scoped);
            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);

            //            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
