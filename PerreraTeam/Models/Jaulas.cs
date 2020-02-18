using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerreraTeam.Models
{
    public class Jaulas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ha de indicar un nombre para la jaula")]
        public string NombreJaula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perros> Perros { get; set; }
    }
}