﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public abstract class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Nombre completo")]
        [Required(ErrorMessage = "Debe de rellenar el nombre")]
        [StringLength(50, ErrorMessage = "Tope máximo de carácteres permitido: 50")]
        public string NombreCompleto { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Tope máximo de carácteres permitido: 20")]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(125, ErrorMessage = "Tope máximo de carácteres permitido: 125")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [RegularExpression(@"(^[0-9]{8})([-]?)([A-Za-z]{1})$", ErrorMessage = "El DNI debe ser válido")]
        public string DNI { get; set; }

        public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}