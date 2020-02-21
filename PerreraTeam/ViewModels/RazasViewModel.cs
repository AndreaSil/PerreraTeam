using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PerreraTeam.Domain.Models;

namespace PerreraTeam.ViewModels
{
    public class RazasViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}