using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ContactRepository : IContact
    {
        private readonly inafocam_tracingContext _context;

        public ContactRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<Contact> GetAll => _context.Contact
            .Include(x => x.ContactType)
            .Include(x => x.CreationUser)
            .Include(x => x.DocumentType)
            .Include(x => x.Status)
            .Include(x => x.UpgradeUser)
            .Include(x => x.Company)
            .Include(x => x.ContactAddres)
            //.Include(x => x.ContactAddress)
            //.Include(x => x.ContactCommunicatio)
            .Include(x => x.ContactCommunication)
            .Include(x => x.Teacher)
            .Include(x => x.User);

        public Contact GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.ContactId == id);
        }

        public void Save(Contact model)
        {
            if(model.ContactId != 0)
            {
                _context.Contact.Update(model);
            }
            else
            {
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
