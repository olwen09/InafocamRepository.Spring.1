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
   public class TeacherRepository : ITeacher
    {
        private readonly inafocam_tracingContext _context;

        public TeacherRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<Teacher> GetAll => _context.Teacher
            .Include(x => x.Contact)
            //.Include(x => x.Contact.ContactAddres)
            .Include(x => x.Contact.Status)
            .Include(x => x.Contact.ContactType)
            .Include(x => x.HigherTeacherEducation)
            .Include(x => x.HigherTeacherEducation.EducationType)
            .Include(x => x.HigherTeacherEducation.TeacherNavigation)
            .Include(x => x.Status)
            .Include(x => x.TeacherHiringType);
            //.Include(x => x.ScholarshipProgramUniversitySubjectMatterPredictedTeacher)
            //.Include(x => x.ScholarshipProgramUniversitySubjectMatterTeacher)
            //.Include(x => x.TeacherEducation)
            //.Include(x => x.TeacherFile)
            //.Include(x => x.TeacherResearch)
            //.Include(x => x.TracingStudyPlanDevelopmentAssignedTeacher)
            //.Include(x => x.TracingStudyPlanDevelopmentTeacher);
            //.Include(x => x.University);


        public Teacher GetById(int id)
        {
            
           return GetAll.FirstOrDefault(x => x.TeacherId == id);
        }



        public int GetContactId(int id)
        {
            return (int)GetAll.FirstOrDefault(x => x.TeacherId == id).ContactId; ;
        }

        public IQueryable<Teacher> GetTeachersByUSerUniversityId(long? userUniversityId)
        {
            return GetAll.Where(x => x.UniversityId == userUniversityId);
        }

        public void Save(Teacher model)
        {

            var now = DateTime.Now;

            if (model.TeacherId !=0)
            {
                model.UpgradeDate = now;
                
                //model.HigherTeacherEducation.TeacherId = model.TeacherId;
                _context.Teacher.Update(model);

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
