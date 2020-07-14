using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingCourseFileRepository : IScholarshipProgramTracingCourseFile
    {

        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingCourseFileRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingCourseFile> GetAll => _context.ScholarshipProgramTracingCourseFile
            .Include(x => x.File)
            .Include(x => x.FileType)
            .Include(x => x.Status)
            .Include(x => x.Tracing);

        public IEnumerable<ScholarshipProgramTracingCourseFile> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public void Save(ScholarshipProgramTracingCourseFile model)
        {
            var now = DateTime.Now;

            if(model.CourseFileId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramTracingCourseFile.Update(model);
            }

            else
            {
                model.CreationDate = now;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
