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
    public class ScholarshipProgramTracingCourseRepository : IScholarshipProgramTracingCourse
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingCourseRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ScholarshipProgramTracingCourse> GetAll => _context.ScholarshipProgramTracingCourse
            .Include(x => x.Status)
            .Include(x => x.Tracing);
          

        public IEnumerable<ScholarshipProgramTracingCourse> GetAllByTracingId(int tracing_id)
        {
            return GetAll.Where(x => x.TracingId == tracing_id);
        }

        public IEnumerable<ScholarshipProgramTracingCourse> GetAvaliableTracingsById(int tracing_id)
        {
            return GetAll.Where(x => x.TracingId == tracing_id && x.Status.StatusName == "Activo");
        }

        public ScholarshipProgramTracingCourse GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(int id)
        {
           var ScholarshipProgramTracingCourse = GetById(id);

            ScholarshipProgramTracingCourse.StatusId = 2;

            _context.ScholarshipProgramTracingCourse.Update(ScholarshipProgramTracingCourse);

            _context.SaveChanges();
        }

        public void Save(ScholarshipProgramTracingCourse model)
        {
            var now = DateTime.Now;

            if(model.Id != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramTracingCourse.Update(model);
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
