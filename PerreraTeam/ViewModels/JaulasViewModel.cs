using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.ViewModels
{
    public class JaulasViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ha de indicar un nombre para la jaula")]
        public string NombreJaula { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}