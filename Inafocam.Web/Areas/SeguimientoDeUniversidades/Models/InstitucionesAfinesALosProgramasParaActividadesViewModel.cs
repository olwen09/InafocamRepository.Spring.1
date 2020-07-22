using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class InstitucionesAfinesALosProgramasParaActividadesViewModel
    {
        public int? TracingId { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }

        public IEnumerable<AgreementWithInstitutionsRelatedToCurricularActivities> RelatedToCurricularActivitiesList { get; set; }
        public AgreementWithInstitutionsRelatedToCurricularActivitiesModel RelatedToCurricularActivitiesModel { get; set; }
    }
}
