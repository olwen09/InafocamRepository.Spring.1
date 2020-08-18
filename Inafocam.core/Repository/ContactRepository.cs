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

        public bool CheckIfContactDocumentNumberExits(Contact model)
        {

            var result = false;
            var data = GetAll.FirstOrDefault(x => x.ContactDocumentNumber == model.ContactDocumentNumber); 

            if(data != null)
            {
             result = data.ContactId == model.ContactId ? false : true;

                _context.Entry(data).State = EntityState.Detached;
                _context.Entry(data.ContactAddres).State = EntityState.Detached;
                _context.Entry(data.ContactCommunication).State = EntityState.Detached;
                //_context.Entry(data.ContactCommunication.Communication).State = EntityState.Detached;

            }


            return result;
        }

        public Contact GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.ContactId == id);
        }

        public void Save(Contact model)
        {
            var now = DateTime.Now;
            
            if(model.ContactId != 0)
            {
                model.UpgradeDate = now;
                _context.Contact.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.StatusId =StatusValues.Activo;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
