using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
    public interface IRole
    {
        IQueryable<Role> Roles { get; }
        Role GetRoleById(string id);
    }
}
