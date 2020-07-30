using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public interface ISubjectMatter
    {
        IQueryable<SubjectMatter> GetAll { get; }

        SubjectMatter GetById(int id);

        IQueryable<SubjectMatter> GetAllByScholarshipProgramUniversityId(int ScholarshipProgramUniversityId);


        void Save(SubjectMatter model);
    }
}
