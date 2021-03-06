﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public class Perros
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ha de indicar un nombre para el perro")]
        [DisplayName("Nombre Perro")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Indique el Chip del perro")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "El chip solo contiene números y letras")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "El chip debe tener 15 dígitos o 10 números y letras")]
        public string Chip { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }

        //[Required(ErrorMessage = "Código de raza del perro")]
        [DisplayFormat(NullDisplayText = "-Desconocida-")]
        public Nullable<int> RazaId { get; set; }

        //[Required(ErrorMessage = "Código de jaula")]
        [DisplayFormat(NullDisplayText = "-Desconocida-")]
        public Nullable<int> JaulaId { get; set; }

        public virtual ICollection<Adopciones> Adopciones { get; set; }
        public virtual Jaulas Jaula { get; set; }
        public virtual Razas Raza { get; set; }
    }
}