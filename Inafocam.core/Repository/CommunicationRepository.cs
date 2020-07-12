using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class CommunicationRepository : ICommunication
    {
        private readonly inafocam_tracingContext _context;

        public CommunicationRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<Communication> GetAll => _context.Communication
            .Include(x => x.Status)
            .Include(x => x.Company)
            .Include(x => x.ContactCommunication)
            .Include(x => x.Office)
            .Include(x => x.University);

        public Communication GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
