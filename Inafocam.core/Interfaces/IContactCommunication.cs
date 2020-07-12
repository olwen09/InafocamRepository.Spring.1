using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IContactCommunication
    {
        IQueryable<ContactCommunication> GetAll { get; }

        IEnumerable<ContactCommunication> GetAllByContactId(int id);

        ContactCommunication GetByContactId(int id);

        void Save(ContactCommunication model);
    }
}