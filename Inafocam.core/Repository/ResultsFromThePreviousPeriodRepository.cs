using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
   public class ResultsFromThePreviousPeriodRepository : IResultsFromThePreviousPeriod
    {
        private readonly inafocam_tracingContext _context;

        public ResultsFromThePreviousPeriodRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ResultsFromThePreviousPeriod> GetAll => _context.ResultsFromThePreviousPeriod
            .Include(x => x.Tracing)
            .Include(x => x.Status)
            .Include(x => x.File)
            .Include(x => x.ComponentFileType);

        public IEnumerable<ResultsFromThePreviousPeriod> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public void Save(ResultsFromThePreviousPeriod model)
        {
            var statusActivate = 1;
            var now = DateTime.Now;

            if(model.PreviousPeriodId != 0)
            {
                var currentData = _context.ResultsFromThePreviousPeriod.Find(model.PreviousPeriodId);


                model.UpgradeDate = now;
                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
            }

            else
            {

                model.StatusId = statusActivate;
                model.CreationDate = now;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
