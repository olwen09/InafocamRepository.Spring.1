﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class TracingStudyPlanDevelopmentModel
    {
        public long Id { get; set; }
        public long? ScholarshipProgramTracingId { get; set; }
        public long? SubjectMatterId { get; set; }
        public long? TeacherId { get; set; }
        public long? AssignedTeacherId { get; set; }
        public long? HigherTitleSupportMatterId { get; set; }
        public double? ScoreAverageStudents { get; set; }
        public int? ApprovedStudentsQuantity { get; set; }
        public string UniverityPeriod { get; set; }

        public int? ReprovedStudentsQuantity { get; set; }
        public int? DesertedStudentsQuantity { get; set; }
        public int? MaleQuantity { get; set; }
        public int? femaleQuantity { get; set; }
        public short? HigherTitleMatchAssignedMatter { get; set; }
        public long? SubjectMatterScoreReportFileId { get; set; }
        public TimeSpan? SubjectMatterTimeStart { get; set; }
        public TimeSpan? SubjectMatterTimeEnd { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public long? StatusId { get; set; }
        public long? StudentReportFileId { get; set; }


        public virtual Teacher AssignedTeacher { get; set; }
        public virtual TeacherEducation HigherTitleSupportMatter { get; set; }
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }
        public virtual File StudentReportFile { get; set; }

        public virtual Status Status { get; set; }
        public virtual SubjectMatter SubjectMatter { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
