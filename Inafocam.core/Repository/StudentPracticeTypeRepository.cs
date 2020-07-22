using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
  public  class StudentPracticeTypeRepository : IStudentPracticeType
    {
        private readonly inafocam_tracingContext _context;

        public StudentPracticeTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentPracticeType> GetAll => _context.StudentPracticeType
            .Include(x => x.Status);
    }
}
