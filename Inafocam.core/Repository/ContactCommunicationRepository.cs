﻿using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ContactCommunicationRepository : IContactCommunication
    {
        private readonly inafocam_tracingContext _context;

        public ContactCommunicationRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ContactCommunication> GetAll => _context.ContactCommunication
            .Include(x => x.Communication)
            .Include(x => x.Contact);

        public IEnumerable<ContactCommunication> GetAllByContactId(int id)
        {
            return GetAll.Where(x => x.ContactId == id);
        }

        public ContactCommunication GetByContactId(int id)
        {
            return GetAll.FirstOrDefault(x => x.ContactId == id);
        }

        public ContactCommunication GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.ContactCommunicationId == id);
        }

        //.Include(x=> x.)
        //.Include(x=> x.)

        public void Save(ContactCommunication model)
        {
            var now = DateTime.Now;

            if(model.ContactCommunicationId != 0)
            {
                model.CreationDate = now;
                model.Communication.CreationDate = now;
                _context.ContactCommunication.Update(model);
            }
            else
            {
                model.UpgradeDate = now;
                model.Communication.UpgradeDate = now;
                model.Communication.StatusId = StatusValues.Activo;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }
            _context.SaveChanges();
        }
    }
}
