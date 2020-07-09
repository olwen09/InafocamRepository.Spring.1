using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class UniversityRepository : IUniversity
    {
        private readonly inafocam_tracingContext _context;
        public UniversityRepository(inafocam_tracingContext context)
        {
            _context = context;
        }
        public IQueryable<University> Universities => _context.University
            .Include(x => x.Address)
            .Include(x => x.Communication)
            .Include(x => x.Status)
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.ScholarshipProgramUniversity)
            .Include(x => x.UserUniversity);

        public University GetById(int id)
        {
          return  Universities.FirstOrDefault(x => x.UniversityId == id);
        }

        public void Save(University data)
        {

            var now = DateTime.Now;

            if(data.UniversityId != 0)
            {

                data.UpgradeDate = now;
                 _context.University.Update(data);


            }

            else
            {
                data.CreationDate = now;
                _context.Add(data);
            }

            _context.SaveChanges();
        }
    }
}
