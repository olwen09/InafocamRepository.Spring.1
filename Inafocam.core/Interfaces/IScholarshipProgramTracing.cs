﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public  interface IScholarshipProgramTracing
    {
        IQueryable<ScholarshipProgramTracing> ScholarshipProgramTracing { get; }

        ScholarshipProgramTracing GetById(long id);

        public long? GetUniversityId(int universityId);

        IEnumerable<ScholarshipProgramTracing> GetTracingByUserUniversityId(int userUniversityId);

        IQueryable<ScholarshipProgramTracing> GetfindAvailableTracings(int tracingId);

        
        void Save(ScholarshipProgramTracing model);
    }
}
