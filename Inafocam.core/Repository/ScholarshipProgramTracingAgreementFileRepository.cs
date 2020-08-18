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


    public class ScholarshipProgramTracingAgreementFileRepository : IScholarshipProgramTracingAgreementFile
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingAgreementFileRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingAgreementFile> GetAll => _context.ScholarshipProgramTracingAgreementFile
            .Include(x => x.File)
            .Include(x => x.Status);

      public  IEnumerable<ScholarshipProgramTracingAgreementFile> GetAllByscholarshipPogramTracingAgreementId(int id)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingAgreementId == id && x.StatusId != StatusValues.Eliminado);
        }

        public void Save(ScholarshipProgramTracingAgreementFile model)
        {
            var now = DateTime.Now;

            if(model.ScholarshipProgramTracingAgreementFileId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramTracingAgreementFile.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }
            _context.SaveChanges();
        }

        public void Delete(long evidenceId)
        {
           
            var evidenciaData = _context.ScholarshipProgramTracingAgreementFile.Find(evidenceId);
            evidenciaData.StatusId = StatusValues.Eliminado;

            _context.ScholarshipProgramTracingAgreementFile.Update(evidenciaData);

            _context.SaveChanges();
        }
    }
}
