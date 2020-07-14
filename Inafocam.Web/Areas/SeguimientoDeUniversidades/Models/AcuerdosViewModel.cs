using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class AcuerdosViewModel
    {

        public int ScholarshipProgramTracingId { get; set; }
        public int ScholarshipProgramUniversityId { get; set; }
        public ScholarshipProgramTracingAgreementModel ScholarshipProgramTracingAgreementModel { get; set; }

        public IEnumerable<ScholarshipProgramUniversityAgreement> ScholarshipProgramUniversityAgreementList { get; set; }

        public IEnumerable<ScholarshipProgramTracingAgreementFile> ScholarshipProgramTracingAgreementFileList { get; set; }
        public ScholarshipProgramTracingAgreementFileModel ScholarshipProgramTracingAgreementFileModel { get; set; }
    }
}
