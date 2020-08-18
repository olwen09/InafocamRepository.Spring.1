using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inafocam.core.Help;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingPracticeRepository : IScholarshipProgramTracingPractice
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingPracticeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingPractice> GetAll => _context.ScholarshipProgramTracingPractice
            .Include(x => x.Tracing)
            .Include(x => x.Status);

        public IEnumerable<ScholarshipProgramTracingPractice> GetAllByTracingId(int traingId)
        {
            return GetAll.Where(x => x.TracingId == traingId).OrderBy(x=> x.ActivityTypeId);
        }

        public ScholarshipProgramTracingPractice GetOneByActivityTypeId(int activityTypeId)
        {
            return GetAll.FirstOrDefault(x => x.ActivityTypeId == activityTypeId);
        }

        public void Save(ScholarshipProgramTracingPractice model)
        {
            var now = DateTime.Now;
           

            var dateString = Convert.ToString(now);

            if(model.Id != 0)
            {
                var currentData = _context.ScholarshipProgramTracingPractice.Find(model.Id);
                model.UpgradeDate = dateString;

                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
            }
            else
            {
                model.CreationDate = dateString;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
