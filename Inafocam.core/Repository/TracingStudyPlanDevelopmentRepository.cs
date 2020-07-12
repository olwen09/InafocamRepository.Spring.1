using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class TracingStudyPlanDevelopmentRepository : ITracingStudyPlanDevelopment
    {
        private readonly inafocam_tracingContext _context;

        public TracingStudyPlanDevelopmentRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<TracingStudyPlanDevelopment> GetAll => _context.TracingStudyPlanDevelopment
            .Include(x => x.Teacher)
            .Include(x => x.AssignedTeacher)
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.Status)
            .Include(x => x.SubjectMatter)
            .Include(x => x.AssignedTeacher);

        public IEnumerable<TracingStudyPlanDevelopment> GetAllByProgramTracingId(int id)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingId == id);
        }

        public TracingStudyPlanDevelopment GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.Id == id);
        }

        public void Save(TracingStudyPlanDevelopment model)
        {
            var now = DateTime.Now;

            if(model.Id != 0)
            {
                model.UpgradeDate = now;
                _context.TracingStudyPlanDevelopment.Update(model);
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
