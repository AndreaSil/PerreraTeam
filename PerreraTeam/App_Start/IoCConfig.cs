using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PerreraTeam.Domain;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services.Repository;

namespace PerreraTeam
{
    public class IoCConfig
    {
        public static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers
                (Assembly.GetExecutingAssembly());
        }

        public static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<PerrosRepository>()
                .As<IPerrosRepository>().InstancePerRequest();
            builder.RegisterType<AdopcionesRepository>()
                .As<IAdopcionesRepository>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Clientes>>()
                .As<IGenericRepository<Clientes>>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Empleados>>()
                .As<IGenericRepository<Empleados>>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Jaulas>>()
                .As<IGenericRepository<Jaulas>>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Razas>>()
                .As<IGenericRepository<Razas>>().InstancePerRequest();
        }

        public static void RegistrarClases(ContainerBuilder builder)
        {
            builder.Register(z => new PerreraContext()).
                InstancePerRequest();
        }
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegistrarControllers(builder);
            RegistrarRepos(builder);
            RegistrarClases(builder);

            var contenedor = builder.Build();

            DependencyResolver.SetResolver
                (new AutofacDependencyResolver(contenedor));
        }
    }
}