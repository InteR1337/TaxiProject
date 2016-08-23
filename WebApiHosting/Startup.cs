using Autofac;
using Autofac.Integration.WebApi;
using DataAccess;
using DataAccessInterfaces;
using DataModel;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiHosting.Controllers;

namespace WebApiHosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.EnableCors();

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //MongoContext mongoContext = new MongoContext();
            //builder.RegisterInstance(mongoContext).As<MongoContext>();
            builder.RegisterType<MongoContext>();
            builder.RegisterType<TaxiRepository>().As<IRepository<Taxi>>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);
        }
    }
}
