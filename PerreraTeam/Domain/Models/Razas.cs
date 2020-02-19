using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerreraTeam.Domain.Models
{
    public class Razas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ha de indicar un nombre para la raza")]
        public string Nombre { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}