using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services.Repository;

namespace PerreraTeam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //construyo el contenedor y registro las clases
            var builder = new ContainerBuilder();
            //builder.RegisterType<GenericRepository<Jaulas>>().As<IGenericRepository();
            builder.RegisterType<AdopcionesRepository>().As<IAdopcionesRepository>().SingleInstance();
            builder.RegisterType<PerrosRepository>().As<IPerrosRepository>().SingleInstance();

            //Container = builder.Build();
            ////dar ámbito de vida a la variable
            //using (var scope = Container.BeginLifetimeScope())
            //{
               
            //}
        }
    }
}
