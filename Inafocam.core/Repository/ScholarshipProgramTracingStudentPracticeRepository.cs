using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingStudentPracticeRepository : IScholarshipProgramTracingStudentPractice
    {

        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingStudentPracticeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingStudentPractice> GetAll => _context.ScholarshipProgramTracingStudentPractice
            .Include(x => x.Status)
            .Include(x => x.StudentPracticeType)
            .Include(x => x.Tracing);

        public IEnumerable<ScholarshipProgramTracingStudentPractice> GetAllByTracingId(long tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public ScholarshipProgramTracingStudentPractice GetOneByStudentPracticeTypeId(long id)
        {
            return GetAll.FirstOrDefault(x => x.StudentPracticeTypeId == id);
        }

        public void Save(ScholarshipProgramTracingStudentPractice model)
        {

            var now = DateTime.Now;
            var activateStatus = 1;
            if(model.Id != 0)
            {
                var currentData = _context.ScholarshipProgramTracingStudentPractice.Find(model.Id);
                model.UpgradeDate = now;
                //_context.ScholarshipProgramTracingStudentPractice.Update(model);

                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
            }
            else
            {
                model.CreationDate = now;
                model.StatusId= activateStatus;
                _context.Add(model);
            }
            _context.SaveChanges();
        }
    }
}
