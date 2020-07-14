using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingCourseFileTypeRepository : IScholarshipProgramTracingCourseFileType
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingCourseFileTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingCourseFileType> GetAll => _context.ScholarshipProgramTracingCourseFileType
            .Include(x => x.ScholarshipProgramTracingCourseFile);


    }
}
