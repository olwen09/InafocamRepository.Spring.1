using Inafocam.core.Modelos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class TeacherFileModel
    {
        public long? TeacherFileId { get; set; }
        public long TeacherId { get; set; }
        public long? TeacherResearchId { get; set; }
        public string TeacherFullName { get; set; }
        public long? FileId { get; set; }

        [Required(ErrorMessage ="El tipo de documento es requerido")]
        public long? TeacherFileTypeId { get; set; }

        [Required]
        public string TeacherFileComment { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public IFormFile FormFile { get; set; }

        public virtual File File { get; set; }
        public virtual Status Status { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<TeacherFile> TeacherFileList { get; set; }
        public virtual ICollection<TeacherFileType> TeacherFileTypeList { get; set; }
        public virtual TeacherFileType TeacherFileType { get; set; }
        public virtual TeacherResearch TeacherResearch { get; set; }
    }
}
