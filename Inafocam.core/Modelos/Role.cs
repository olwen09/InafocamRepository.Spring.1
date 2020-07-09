using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Modelos
{
   public  class Role : IdentityRole
    {
        public Role(string name, string descripcion) : base(name)
        {
            Name = name;
            Descripcion = descripcion;
        }

        public Role() : base() { }

        public string Descripcion { get; set; }
    }
}
