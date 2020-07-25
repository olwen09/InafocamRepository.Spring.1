﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingStudentSupportModel
    {
        public long Id { get; set; }
        public long TracingId { get; set; }
        public long? IndicatorId { get; set; }
        public long? QuestionId { get; set; }
        public string Cuálesutilizan { get; set; }
        public string ComoLoHacenProcedimiento { get; set; }
        public string CuandoSeHacePeriodicidad { get; set; }
        public string QuienEsElResponsable { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
