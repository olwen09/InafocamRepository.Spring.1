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
            .Include(x => x.Tracing)
            .Include(x => x.ScholarshipProgramTracingCourse);

        public ScholarshipProgramTracingCourseFile CheckIfTheFileExits(long? fileTypeId, long? CourseId)
        {
            return GetAll.FirstOrDefault(x => x.FileTypeId == fileTypeId && x.ScholarshipProgramTracingCourseId == CourseId);
        }

        public IEnumerable<ScholarshipProgramTracingCourseFile> GetAllByCourseIdAndTracingId(int tracingId, int courseId)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingCourseId == courseId && x.TracingId == tracingId);
        }



        public void Save(ScholarshipProgramTracingCourseFile model)
        {
            var now = DateTime.Now;

            if(model.CourseFileId != 0)
            {
                model.UpgradeDate = now;

                var currentData = _context.ScholarshipProgramTracingCourseFile.Find(model.CourseFileId);
     
                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
                _context.ScholarshipProgramTracingCourseFile.Update(model);
            }

            else
            {
                model.CreationDate = now;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
