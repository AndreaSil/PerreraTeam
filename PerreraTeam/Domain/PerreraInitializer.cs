using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Domain
{
    public class PerreraInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PerreraContext>
    {
        protected override void Seed(PerreraContext context)
        {

            var razas = new List<Razas>
            {
                new Razas(){Nombre = "Labrador"},
                new Razas(){Nombre = "Husky"},
                new Razas(){Nombre = "Bulldog"},
                new Razas(){Nombre = "Pug"}
            };

            razas.ForEach(r => context.Razas.Add(r));
            context.SaveChanges();

            var jaulas = new List<Jaulas>
            {
                new Jaulas(){NombreJaula = "JaulaGrande"},
                new Jaulas(){NombreJaula = "JaulaPequena"}
            };

            jaulas.ForEach(j => context.Jaulas.Add(j));
            context.SaveChanges();

            var perros = new List<Perros>
            {
            new Perros(){Nombre = "Toby",Chip = "01ABHGIUTO",FechaNacimiento = new DateTime(2011,03,13),Razas = razas[0],Jaulas = jaulas[0]},
            new Perros(){Nombre = "Scar",Chip = "02ABHGIUTO",FechaNacimiento = new DateTime(2012,04,14),Razas = razas[1],Jaulas = jaulas[0]},
            new Perros(){Nombre = "Pere",Chip = "03ABHGIUTO",FechaNacimiento = new DateTime(2013,05,15),Razas = razas[2],Jaulas = jaulas[1]},
            new Perros(){Nombre = "Soso",Chip = "04ABHGIUTO",FechaNacimiento = new DateTime(2014,06,16),Razas = razas[3],Jaulas = jaulas[1]},

            };
            perros.ForEach(p => context.Perros.Add(p));
            context.SaveChanges();

            var empleados = new List<Empleados>
            {
                new Empleados(){NombreCompleto = "Andrea",Correo = "Andrea@perrera.com",DNI = "74957645O",Telefono = "654875970"},
                new Empleados(){NombreCompleto = "Alex",Correo = "Alex@perrera.com",DNI = "74957646O",Telefono = "654876470"},
                new Empleados(){NombreCompleto = "Raquel",Correo = "Raquel@perrera.com",DNI = "74927645O",Telefono = "654826970"},
                new Empleados(){NombreCompleto = "Sergio",Correo = "Sergio@perrera.com",DNI = "74997645O",Telefono = "654876870"},
            };

            empleados.ForEach(e => context.Empleados.Add(e));
            context.SaveChanges();

            var clientes = new List<Clientes>
            {
                new Clientes(){NombreCompleto = "AndreaC",Correo = "AndreaC@perrera.com",DNI = "74957646O",Telefono = "624875970"},
                new Clientes(){NombreCompleto = "AlexC",Correo = "AlexC@perrera.com",DNI = "74957641O",Telefono = "654876670"},
                new Clientes(){NombreCompleto = "RaquelC",Correo = "RaquelC@perrera.com",DNI = "74947645O",Telefono = "654726970"},
                new Clientes(){NombreCompleto = "Sergio",Correo = "SergioC@perrera.com",DNI = "64997645O",Telefono = "654896870"},
            };

            clientes.ForEach(c => context.Clientes.Add(c));
            context.SaveChanges();

            var adopciones = new List<Adopciones>
            {
                new Adopciones(){ClienteId = 1,EmpleadoId = 1,PerroId = 1,FechaEntrega = new DateTime(2015,01,15)},
                new Adopciones(){ClienteId = 2,EmpleadoId = 2,PerroId = 2,FechaEntrega = new DateTime(2016,02,16)},
                new Adopciones(){ClienteId = 3,EmpleadoId = 3,PerroId = 3,FechaEntrega = new DateTime(2017,03,17)},
            };

            adopciones.ForEach(a => context.Adopciones.Add(a));
            context.SaveChanges();

        }
    }
}