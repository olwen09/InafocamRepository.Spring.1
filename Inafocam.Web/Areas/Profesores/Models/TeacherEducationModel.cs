using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class TeacherEducationModel
    {
        
        public long TeacherEducationId { get; set; }
        public long TeacherId { get; set; }

        public string TeacherFullName { get; set; }

        [Required(ErrorMessage = "El {0} es Requerido")]
        [Display(Name ="Titulo de Educacion")]
        public string TeacherEducationTitle { get; set; }

        [Required(ErrorMessage = "El {0} es Requerido")]
        [Display(Name = "Tipo de Educacion")]
        public long? EducationTypeId { get; set; }

        [Required(ErrorMessage = "La {0} es Requerida")]
        [Display(Name = "Fecha de Término")]
        public DateTime? TeacherEducationFinishDate { get; set; }

        [Required(ErrorMessage = "La {0} es Requerida")]
        [Display(Name = "Institución Formadora")]
        public string TeacherEducationInstitution { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual EducationType EducationType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Teacher TeacherNavigation { get; set; }
        public virtual ICollection<TeacherEducation> TeacherEducationList { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<TracingStudyPlanDevelopment> TracingStudyPlanDevelopment { get; set; }
    }
}
