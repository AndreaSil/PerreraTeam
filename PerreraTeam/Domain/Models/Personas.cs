using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public abstract class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe de rellenar el nombre")]
        [StringLength(50, ErrorMessage = "Tope máximo de carácteres permitido: 50")]
        public string NombreCompleto { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Tope máximo de carácteres permitido: 20")]
        public string Telefono { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(125, ErrorMessage = "Tope máximo de carácteres permitido: 125")]
        public string Correo { get; set; }

        [RegularExpression(@"(^[0-9]{8})([-]?)([A-Za-z]{1})$", ErrorMessage = "El DNI debe ser válido")]
        public string DNI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}