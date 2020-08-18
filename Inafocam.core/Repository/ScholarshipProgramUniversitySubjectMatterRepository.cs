using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
  public  class ScholarshipProgramUniversitySubjectMatterRepository : IScholarshipProgramUniversitySubjectMatter
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramUniversitySubjectMatterRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public void Save(ScholarshipProgramUniversitySubjectMatter model)
        {
            var now = DateTime.Now;

            if(model.ScholarshipProgramUniversitySubjectMatterId != 0)
            {
               
                _context.ScholarshipProgramUniversitySubjectMatter.Update(model);
            }
            else
            {
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }
            _context.SaveChanges();
        }
    }
}
