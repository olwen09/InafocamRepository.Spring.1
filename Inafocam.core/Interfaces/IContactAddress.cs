using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IContactAddress
    {
        IQueryable<ContactAddress> GetAll { get; }

        IEnumerable<ContactAddress> GetByContactId(int id);

        ContactAddress GetById(int id);

        void Save(ContactAddress model);
    }
}
