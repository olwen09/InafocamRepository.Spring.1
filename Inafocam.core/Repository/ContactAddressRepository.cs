using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ContactAddressRepository : IContactAddress
    {

        private readonly inafocam_tracingContext _context;

        public ContactAddressRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ContactAddress> GetAll => _context.ContactAddress
            .Include(x => x.Address)
            .Include(x => x.Address.AddressType)
            .Include(x => x.Address.Province)
            .Include(x => x.Address.City)
            .Include(x => x.Contact)
            .Include(x => x.Status)
            //.Include(x => x.)
            .Include(x => x.Address.Country);

        public ContactAddress GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.ContactAddressId == id);
        }

        public IEnumerable<ContactAddress> GetByContactId(int id)
        {
            return GetAll.Where(x => x.ContactId == id);
        }

    

        public void Save(ContactAddress model)
        {
            var now = DateTime.Now;

           if(model.ContactAddressId != 0)
            {
                model.UpgradeDate = now;
                model.Address.UpgradeDate = now;
                _context.ContactAddress.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.Address.CreationDate = now;
                model.Address.StatusId = StatusValues.Activo;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
