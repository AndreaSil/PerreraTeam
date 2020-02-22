using System.Collections.Generic;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PerreraTeam.Domain.PerreraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PerreraTeam.Domain.PerreraContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var razas = new List<Razas>
            {
                new Razas(){Nombre = "Labrador"},
                new Razas(){Nombre = "Husky"},
                new Razas(){Nombre = "Bulldog"},
                new Razas(){Nombre = "Pug"}
            };

            razas.ForEach(r => context.Razas.AddOrUpdate(p =>p.Nombre, r));
            context.SaveChanges();

            var jaulas = new List<Jaulas>
            {
                new Jaulas(){NombreJaula = "Jaula Grande"},
                new Jaulas(){NombreJaula = "Jaula Pequeña"}
            };

            jaulas.ForEach(j => context.Jaulas.AddOrUpdate(p=>p.NombreJaula, j));
            context.SaveChanges();

            var perros = new List<Perros>
            {
            new Perros(){Nombre = "Toby",Chip = "000001aaaa",FechaNacimiento = new DateTime(2011,03,13),Raza = razas[0],Jaula = jaulas[0]},
            new Perros(){Nombre = "Scar",Chip = "000002bbbb",FechaNacimiento = new DateTime(2012,04,14),Raza = razas[1],Jaula = jaulas[0]},
            new Perros(){Nombre = "Pere",Chip = "000003cccc",FechaNacimiento = new DateTime(2013,05,15),Raza = razas[2],Jaula = jaulas[1]},
            new Perros(){Nombre = "Soso",Chip = "000004dddd",FechaNacimiento = new DateTime(2014,06,16),Raza = razas[3],Jaula = jaulas[1]},
            new Perros(){Nombre = "Roi",Chip = "000005eeee",FechaNacimiento = new DateTime(2015,12,10),Raza = razas[3],Jaula = jaulas[1]},
            new Perros(){Nombre = "Lobo",Chip = "000006ffff",FechaNacimiento = new DateTime(2016,01,26),Raza = razas[1],Jaula = jaulas[0]},
            new Perros(){Nombre = "Linda",Chip = "000007gggg",FechaNacimiento = new DateTime(2017,06,16),Raza = razas[0],Jaula = jaulas[0]}
            };
            perros.ForEach(p => context.Perros.AddOrUpdate(e=>e.Chip, p));
            context.SaveChanges();

            var empleados = new List<Empleados>
            {
                new Empleados(){NombreCompleto = "Andrea",Correo = "Andrea@perrera.com",DNI = "74957645O",Telefono = "654875970"},
                new Empleados(){NombreCompleto = "Alex",Correo = "Alex@perrera.com",DNI = "74957646O",Telefono = "654876470"},
                new Empleados(){NombreCompleto = "Raquel",Correo = "Raquel@perrera.com",DNI = "74927645O",Telefono = "654826970"},
                new Empleados(){NombreCompleto = "Sergio",Correo = "Sergio@perrera.com",DNI = "74997645O",Telefono = "654876870"},
            };

            empleados.ForEach(e => context.Empleados.AddOrUpdate(p=>p.DNI, e));
            context.SaveChanges();

            var clientes = new List<Clientes>
            {
                new Clientes(){NombreCompleto = "AndreaC",Correo = "AndreaC@perrera.com",DNI = "74957646O",Telefono = "624875970"},
                new Clientes(){NombreCompleto = "AlexC",Correo = "AlexC@perrera.com",DNI = "74957641O",Telefono = "654876670"},
                new Clientes(){NombreCompleto = "RaquelC",Correo = "RaquelC@perrera.com",DNI = "74947645O",Telefono = "654726970"},
                new Clientes(){NombreCompleto = "SergioC",Correo = "SergioC@perrera.com",DNI = "64997645O",Telefono = "654896870"},
            };

            clientes.ForEach(c => context.Clientes.Add(c));
            context.SaveChanges();

            var adopciones = new List<Adopciones>
            {
                new Adopciones(){ClienteId = clientes[0].Id,EmpleadoId = empleados[0].Id,PerroId = perros[0].Id,FechaEntrega = new DateTime(2015,01,15)},
                new Adopciones(){ClienteId = clientes[1].Id,EmpleadoId = empleados[1].Id,PerroId = perros[1].Id,FechaEntrega = new DateTime(2016,02,16)},
                new Adopciones(){ClienteId = clientes[2].Id,EmpleadoId = empleados[2].Id,PerroId = perros[2].Id,FechaEntrega = new DateTime(2017,03,17)},
                new Adopciones(){ClienteId = clientes[0].Id,EmpleadoId = empleados[0].Id,PerroId = perros[3].Id,FechaEntrega = new DateTime(2017,03,17)}
            };

            foreach (var adoption in adopciones)
            {
                var adoptionInDataBase = context.Adopciones.SingleOrDefault
                                (a => a.Cliente.Id == adoption.ClienteId &&
                                             a.Empleado.Id == adoption.EmpleadoId &&
                                             a.Perro.Id == adoption.PerroId &&
                                             a.FechaEntrega == adoption.FechaEntrega);
                if (adoptionInDataBase == null)
                {
                    context.Adopciones.Add(adoption);
                }
            }
            context.SaveChanges();
        }
    }
}
