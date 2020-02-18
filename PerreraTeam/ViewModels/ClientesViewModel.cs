﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerreraTeam.ViewModels
{
    public class ClientesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe utilizar un nombre completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Se requiere un numero de contacto")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [RegularExpression("^[0-9]{8,8}[A-Za-z]$"),]
        public string DNI { get; set; }

     //   [System.Diagnostics.CodeAnalysis.
      //      SuppressMessage("Microsoft.Usage",
      //          "CA2227:CollectionPropertiesShouldBeReadOnly")]
      //  public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}