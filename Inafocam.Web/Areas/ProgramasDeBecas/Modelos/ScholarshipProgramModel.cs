﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ProgramasDeBecas.Modelos
{
    public class ScholarshipProgramModel
    {
        public long ScholarshipProgramId { get; set; }

        [Required(ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Nombre del Programa")]
        public string ScholarshipProgramName { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Nivel escolar")]
        public long? ScholarshipLevelId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "estado")]
        public long? StatusId { get; set; }

        public virtual ScholarshipLevel ScholarshipLevel { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramUniversity ScholarshipProgramUniversity { get; set; }
        public virtual ICollection<ScholarshipProgramUniversity> ScholarshipProgramUniversityList { get; set; }
    }
}
