using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public class Jaulas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ha de indicar un nombre para la jaula")]
        [DisplayName("Nombre Jaula")]
        public string NombreJaula { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}