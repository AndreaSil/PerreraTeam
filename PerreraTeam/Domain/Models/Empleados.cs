using System.Collections.Generic;

namespace PerreraTeam.Domain.Models
{
    public class Empleados : Personas
    {
        public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}