using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.ViewModels
{
    public class AdopcionesViewModel
    {
        public int PerroId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Se requiere una fecha de entrega correcta")]
        public System.DateTime FechaEntrega { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Perros Perros { get; set; }
    }
}