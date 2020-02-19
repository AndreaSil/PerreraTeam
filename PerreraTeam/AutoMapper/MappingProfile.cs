using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using PerreraTeam.Domain.Models;
using PerreraTeam.ViewModels;

namespace PerreraTeam.AutoMapper
{
    public class MappingProfile : Profile
    {

        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Perros, PerrosViewModel>();
                    cfg.CreateMap<Jaulas, JaulasViewModel>();
                    cfg.CreateMap<Adopciones, AdopcionesViewModel>();
                    cfg.CreateMap<Empleados, EmpleadosViewModel>();
                    cfg.CreateMap<Clientes, ClientesViewModel>();
                    cfg.CreateMap<Razas, RazasViewModel>();
                });
            return config;
        }



    }
}