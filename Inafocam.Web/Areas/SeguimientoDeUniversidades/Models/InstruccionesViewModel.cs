﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class InstruccionesViewModel
    {
        public string Instrucciones { get; set; }


        public int ScholarshipProgramTracingId { get; set; }

        public int ScholarshipProgramUniversityId { get; set; }

        public List<string> InstruccionesList { get; set; } 
    }
}