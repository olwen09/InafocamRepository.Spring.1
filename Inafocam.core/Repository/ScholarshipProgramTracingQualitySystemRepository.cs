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
    public class ScholarshipProgramTracingQualitySystemRepository : IScholarshipProgramTracingQualitySystem
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingQualitySystemRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingQualitySystem> GetAll => _context.ScholarshipProgramTracingQualitySystem
            .Include(x => x.File)
            .Include(x => x.Status)
            .Include(x => x.Tracing)
            .Include(x => x.FileType);

        public IEnumerable<ScholarshipProgramTracingQualitySystem> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId && x.StatusId == StatusValues.Activo);
        }

        public void Save(ScholarshipProgramTracingQualitySystem model)
            {
            var now = DateTime.Now;           

            if(model.QualityFileId != 0)
            {
                var currentData = _context.ScholarshipProgramTracingQualitySystem.Find(model.QualityFileId);
                model.File.UpgradeDate = now;
                model.UpgradeDate = now;

                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
       
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
