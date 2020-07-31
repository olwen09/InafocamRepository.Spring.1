using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class SubjectMatterRepository : ISubjectMatter
    {
        private readonly inafocam_tracingContext _context;

        public SubjectMatterRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<SubjectMatter> GetAll => _context.SubjectMatter
            .Include(x => x.CreationUser)
            .Include(x => x.Status)
            .Include(x => x.UpgradeUser)
            .Include(x => x.ScholarshipProgramUniversity)
            .Include(x => x.ScholarshipProgramUniversitySubjectMatter)
            .Include(x => x.TracingStudyPlanDevelopment)
            .Include(x => x.TracingStudyPlanDevelopment.SubjectMatterScoreReportFile);

        public bool CheckIfSubjectMatterCodeExits(SubjectMatter subjectMatter)
        {

            var checkIfItExits = GetAll.FirstOrDefault(x => x.SubjectMatterCode == subjectMatter.SubjectMatterCode
            && x.SubjectMatterId == subjectMatter.SubjectMatterId) != null ? true : false;



            return checkIfItExits;
        }

        public IQueryable<SubjectMatter> GetAllByScholarshipProgramUniversityId(int ScholarshipProgramUniversityId)
        {
            return GetAll.Where(x => x.ScholarshipProgramUniversityId == ScholarshipProgramUniversityId);
        }



        public SubjectMatter GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.SubjectMatterId == id);
        }



        public void Save(SubjectMatter model)
        {
            var now = DateTime.Now;

           if(model.SubjectMatterId != 0)
            {
                model.UpgradeDate = now;
                //var currentData = _context.File.Find(model.SubjectMatterId);

                //_context.Entry(currentData).CurrentValues.SetValues(model);
                //_context.Entry(currentData).State = EntityState.Modified;

                _context.SubjectMatter.Update(model);
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
