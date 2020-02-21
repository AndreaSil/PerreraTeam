namespace PerreraTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopciones",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        PerroId = c.Int(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClienteId, t.EmpleadoId, t.PerroId, t.FechaEntrega })
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Perros", t => t.PerroId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.PerroId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(maxLength: 20),
                        Correo = c.String(maxLength: 125),
                        DNI = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(maxLength: 20),
                        Correo = c.String(maxLength: 125),
                        DNI = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Perros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Chip = c.String(nullable: false, maxLength: 15),
                        FechaNacimiento = c.DateTime(),
                        RazaId = c.Int(nullable: false),
                        JaulaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jaulas", t => t.JaulaId, cascadeDelete: true)
                .ForeignKey("dbo.Razas", t => t.RazaId, cascadeDelete: true)
                .Index(t => t.RazaId)
                .Index(t => t.JaulaId);
            
            CreateTable(
                "dbo.Jaulas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreJaula = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Perros", "RazaId", "dbo.Razas");
            DropForeignKey("dbo.Perros", "JaulaId", "dbo.Jaulas");
            DropForeignKey("dbo.Adopciones", "PerroId", "dbo.Perros");
            DropForeignKey("dbo.Adopciones", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Adopciones", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Perros", new[] { "JaulaId" });
            DropIndex("dbo.Perros", new[] { "RazaId" });
            DropIndex("dbo.Adopciones", new[] { "PerroId" });
            DropIndex("dbo.Adopciones", new[] { "EmpleadoId" });
            DropIndex("dbo.Adopciones", new[] { "ClienteId" });
            DropTable("dbo.Razas");
            DropTable("dbo.Jaulas");
            DropTable("dbo.Perros");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Adopciones");
        }
    }
}
