using Inafocam.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Modelos
{
    public class ScholarshipProgramTracingPracticePlanningRepository : IScholarshipProgramTracingPracticePlanning
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingPracticePlanningRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingPracticePlanning> GetAll => _context.ScholarshipProgramTracingPracticePlanning
            .Include(x => x.Tracing)
            .Include(x => x.Status)
            .Include(x => x.ActionType);

        public IEnumerable<ScholarshipProgramTracingPracticePlanning> GetAllByTracingId(long tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public ScholarshipProgramTracingPracticePlanning GetOneByActionType(long actionTypeId)
        {
            return GetAll.FirstOrDefault(x => x.ActionTypeId == actionTypeId);
        }

        public void Save(ScholarshipProgramTracingPracticePlanning model)
        {
            var now = DateTime.Now;
            var stactusActivate = 1;
            if(model.Id != 0)
            {


                var currentData = _context.ScholarshipProgramTracingPracticePlanning.Find(model.Id);

                model.UpgradeDate = now;

                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
            }
            else
            {
                model.CreationDate = now;
                model.StatusId = stactusActivate;
                _context.Add(model);

            }

            _context.SaveChanges();
        }
    }
}
