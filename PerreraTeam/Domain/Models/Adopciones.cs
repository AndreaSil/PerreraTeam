﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public class Adopciones
    {
        [Key]
        [Column (Order = 1)]
        [ForeignKey("Perros")]
        [DisplayName("Perro")]
        public int PerroId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Clientes")]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("Empleados")]
        [DisplayName("Empleado")]
        public int EmpleadoId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Indicad la fecha de la adopción.")]
        public System.DateTime FechaEntrega { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Perros Perros { get; set; }
    }
}