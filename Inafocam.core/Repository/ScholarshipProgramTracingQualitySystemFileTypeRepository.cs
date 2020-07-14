using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingQualitySystemFileTypeRepository : IScholarshipProgramTracingQualitySystemFileType
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingQualitySystemFileTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingQualitySystemFileType> GetAll => _context.ScholarshipProgramTracingQualitySystemFileType
            .Include(x => x.Status);
    }
}
