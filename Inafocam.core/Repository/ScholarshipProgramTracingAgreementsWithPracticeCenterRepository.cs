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
    public class ScholarshipProgramTracingAgreementsWithPracticeCenterRepository : IScholarshipProgramTracingAgreementsWithPracticeCenter
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingAgreementsWithPracticeCenterRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingAgreementsWithPracticeCenter> GetAll => _context.ScholarshipProgramTracingAgreementsWithPracticeCenter
            .Include(x => x.Tracing)
            .Include(x => x.Status);

        public IEnumerable<ScholarshipProgramTracingAgreementsWithPracticeCenter> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public ScholarshipProgramTracingAgreementsWithPracticeCenter GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.AgreementsWithPracticeCenterId == id);
        }

        public void Save(ScholarshipProgramTracingAgreementsWithPracticeCenter model)
        {
            var now = DateTime.Now;
         

            if(model.AgreementsWithPracticeCenterId != 0)
            {
                model.UpgradeDate = now;

                _context.ScholarshipProgramTracingAgreementsWithPracticeCenter.Update(model);
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
