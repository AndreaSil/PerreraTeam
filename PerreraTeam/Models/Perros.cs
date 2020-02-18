using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerreraTeam.Models
{
    public class Perros
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ha de indicar un nombre para el perro")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Indique el Chip del perro")]
        public string Chip { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Código de raza del perro")]
        public Nullable<int> CodRazaId { get; set; }

        [Required(ErrorMessage = "Código de jaula")]
        public Nullable<int> IdJaula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Adopciones> Adopciones { get; set; }
        public virtual Jaulas Jaulas { get; set; }
        public virtual Razas Razas { get; set; }
    }
}