using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class TeacherHiringTypeRepository : ITeacherHiringType
    {
        private readonly inafocam_tracingContext _context;

        public TeacherHiringTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }
        public IQueryable<TeacherHiringType> GetAll => _context.TeacherHiringType
            .Include(x => x.Teacher)
            .Include(x => x.Status);
          
    }
}
