using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface IScholarshipProgramTracingCourse
    {
       IQueryable<ScholarshipProgramTracingCourse> GetAll { get; }

        public ScholarshipProgramTracingCourse GetById(int id);

        void Remover(int id);

        public IEnumerable<ScholarshipProgramTracingCourse> GetAllByTracingId(int tracing_id);
        public IEnumerable<ScholarshipProgramTracingCourse> GetAvaliableTracingsById(int tracing_id);

        void Save(ScholarshipProgramTracingCourse model);

    }
}
