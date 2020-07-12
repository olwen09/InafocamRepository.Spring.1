using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public string Role { get; set; }
        public bool Estado { get; set; }
        public long? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public University University { get; set; }
    }
}
