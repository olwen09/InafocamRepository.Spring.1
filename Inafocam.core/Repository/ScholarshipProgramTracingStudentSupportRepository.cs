using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingStudentSupportRepository : IScholarshipProgramTracingStudentSupport
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingStudentSupportRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingStudentSupport> GetAll => _context.ScholarshipProgramTracingStudentSupport
            .Include(x => x.Status)
            .Include(x => x.Tracing);

        public ScholarshipProgramTracingStudentSupport GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<ScholarshipProgramTracingStudentSupport> GetAllByTracingId(int id)
        {
            
            return GetAll.Where(x => x.TracingId == id);
        }

        public void Save(ScholarshipProgramTracingStudentSupport model)
        {
            var now = DateTime.Now;
            if(model.Id != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramTracingStudentSupport.Update(model);
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
