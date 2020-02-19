using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.ViewModels
{
    public class ClientesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe utilizar un nombre completo")]
        [DisplayName("Nombre Cliente")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Se requiere un numero de contacto")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [RegularExpression(@"(^[0-9]{8})([-]?)([A-Za-z]{1})$", ErrorMessage = "El DNI debe ser válido")]
        public string DNI { get; set; }

        public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}