using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
  public  class ScholarshipProgramTracingRepository : IScholarshipProgramTracing
    {

        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ScholarshipProgramTracing> ScholarshipProgramTracing => _context.ScholarshipProgramTracing
            .Include(x => x.Coordinator)
            .Include(x => x.Coordinator.Contact)
            .Include(x => x.ScholarshipProgramUniversity)
            .Include(x => x.ScholarshipProgramUniversity.ScholarshipProgram)
            .Include(x => x.Status)
            .Include(x => x.Technical.Contact)
            .Include(x => x.University)
            .Include(x => x.UpgradeUser);
            //.Include(x => x.ScholarshipProgramTracingAgreement)
            //.Include(x => x.ScholarshipProgramTracingCourse)
            //.Include(x => x.ScholarshipProgramTracingCourseFile)
            //.Include(x => x.ScholarshipProgramTracingPractice)
            //.Include(x => x.ScholarshipProgramTracingPracticePlanning)
            //.Include(x => x.ScholarshipProgramTracingQualitySystem)
            //.Include(x => x.ScholarshipProgramTracingStudentPractice)
            //.Include(x => x.ScholarshipProgramTracingStudentSupport);



        public ScholarshipProgramTracing GetById(long id)
        {
            return ScholarshipProgramTracing.FirstOrDefault(x => x.ScholarshipProgramTracingId == id);
        }

        public IQueryable<ScholarshipProgramTracing> GetfindAvailableTracings(int universityId)
        {
           
            return ScholarshipProgramTracing.Where(x => x.UniversityId == universityId && x.Status.StatusName == "Activo");
        }

        public IEnumerable<ScholarshipProgramTracing> GetTracingByUserUniversityId(int userUniversityId)
        {
            var scholarshipProgramTracing = new List<ScholarshipProgramTracing>();
            var now = DateTime.Today;
            var estadoCerrado = 9;
            
            

            foreach (var item in ScholarshipProgramTracing)
            {
                var date = item.EndDate - now;
                if (date.Value.TotalDays <= 0 && item.Status.StatusName != "Cerrado")
                {
                    
                scholarshipProgramTracing.Add(item);

                }

            }

            foreach(var item in scholarshipProgramTracing)
            {
                item.StatusId = estadoCerrado;
                Save(item);
            }

            return ScholarshipProgramTracing.Where(x => x.UniversityId == userUniversityId);
        }

        public long? GetUniversityId(int tracingId)
        {
            return GetById(tracingId).UniversityId;
        }

        public void Save(ScholarshipProgramTracing model)
        {
         
            var now = DateTime.Today;
            var estadoActivo = 1;
            var date = model.EndDate - now;

          if(model.ScholarshipProgramTracingId != 0)
            {
                if (date.Value.TotalDays > 0)
                {
                    model.StatusId = estadoActivo;
                }

                model.UpgradeDate = now;
                _context.ScholarshipProgramTracing.Update(model);
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
