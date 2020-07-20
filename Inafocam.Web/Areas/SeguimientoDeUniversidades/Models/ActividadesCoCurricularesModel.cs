﻿using Humanizer;
using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ActividadesCoCurricularesModel
    {
        public ScholarshipProgramTracingCourseModel TracingCourseModel { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }
        public int? TracingId { get; set; }

        public ScholarshipProgramTracingCourseFileModel TracingCourseFileModel  { get; set; }
        public ScholarshipProgramTracingCourseFileTypeModel TracingCourseFileTypeModel { get; set; }
        public IEnumerable<ScholarshipProgramTracingCourse> TracingCourseList { get; set; }
        public IEnumerable<ScholarshipProgramTracingCourseFile> TracingCourseFileList { get; set; }

    }
}