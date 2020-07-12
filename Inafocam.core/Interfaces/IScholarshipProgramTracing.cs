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

        ScholarshipProgramTracing GetById(int id);

        IQueryable<ScholarshipProgramTracing> GetTracingByUserUniversityId(int UserUniversityId);

        IQueryable<ScholarshipProgramTracing> GetfindAvailableTracings(int universityId);
        void Save(ScholarshipProgramTracing model);
    }
}
