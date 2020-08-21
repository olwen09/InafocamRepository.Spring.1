using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingAgreementDescriptionRepository : IScholarshipProgramTracingAgreementDescription
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingAgreementDescriptionRepository(inafocam_tracingContext context)
        {
            _context = context;
        }
        public IEnumerable<ScholarshipProgramTracingAgreementDescription> GetAll => _context.ScholarshipProgramTracingAgreementDescription
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.ScholarshipProgramUniversityAgreement)
            .Include(x => x.Status);

        public IEnumerable<ScholarshipProgramTracingAgreementDescription> GetAllByScholarshipProgramUniversityId(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(ScholarshipProgramTracingAgreementDescription model)
        {
            var now = DateTime.Now;
            if (model.ScholarshipProgramTracingAgreementDescriptionId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramTracingAgreementDescription.Update(model);
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
