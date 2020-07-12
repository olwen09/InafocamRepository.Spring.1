using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingCourseRepository : IScholarshipProgramTracingCourse
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingCourseRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ScholarshipProgramTracingCourse> GetAll => throw new NotImplementedException();
    }
}
