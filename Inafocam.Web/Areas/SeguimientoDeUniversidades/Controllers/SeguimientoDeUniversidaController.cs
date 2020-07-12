using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.SeguimientoDeUniversidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Controllers
{

    [Area("SeguimientoDeUniversidades"),ReturnArea("SeguimientoDeUniversidades")]
    [ReturnControllador("Seguimiento De Universidades"),ReturnController("SeguimientoDeUniversida")]
    public class SeguimientoDeUniversidaController : Controller
    {
        private readonly IScholarshipProgramTracing _scholarshipProgramTracing;
        private readonly IScholarshipProgramTracingStudentSupport _studentSupport;  

        public SeguimientoDeUniversidaController(IScholarshipProgramTracing scholarshipProgramTracing, IScholarshipProgramTracingStudentSupport studentSupport)
        {
            _scholarshipProgramTracing = scholarshipProgramTracing;
            _studentSupport = studentSupport;
        }


        public IActionResult Index()
        {
           

            return View(_scholarshipProgramTracing.ScholarshipProgramTracing);
        }

        public IActionResult Instrucciones()
        {

            var model = new InstruccionesViewModel();

            string[] instrucciones = {
                "Preparar la evidencia",
                "Llenar correctamente la información",
                "Ser honesto al responder"
            };

            var lista = new List<string>();
            var count = 0;
            var instrucion = "";
            foreach (var item in instrucciones)
            {

                count += 1;
                instrucion = count + "." + item;
                lista.Add(instrucion);
            }

            model.InstruccionesList = lista;

            return View(model);
        }

        public IActionResult InformacionPrincipal()
        {
            return View();
        }

        public IActionResult Acuerdos()
        {
            return View();
        }

        public IActionResult DesarrolloDelPlanDeEstudio()
        {
            return View();
        }

        public IActionResult ActividadesCoCurriculares()
        {
            return View();
        }

        public IActionResult DocumentoParaElSistemaDeCalidad()
        {
            return View();
        }

        public IActionResult ApoyoAlStudiante()
        {

            var studentSupport = _studentSupport.GetAllByTracingId(1);


            //var data = CopyPropierties.Convert<ApoyoAlEstudianteModel, ScholarshipProgramTracingStudentSupport>(studentSupport);

            var model = new ApoyoAlEstudianteModel
            {
                IndicadoresList = GetIndicadores().IndicadoresList,
                PreguntasList = GetPreguntas().PreguntasList
            };
          
            return View(model);
        }


        public ApoyoAlEstudianteModel GetIndicadores()
        {
            string[] indicadores =
            {
                "Mecanismos para la Identificación de necesidades de apoyo de los alumnos",
                "Estrategias de intervención para el apoyo de los alumnos puestas en marcha",
                "Niveles de satisfacción de los estudiantes con el sistema de apoyo",
                "Resultados de la gestión del sistema de apoyos al estudiante"
            };

            string[] preguntas =
            {
                "¿Cuáles utilizan?",
                "¿Cómo lo hacen? Procedimiento",
                "¿Cuándo se hace? Periodicidad",
                "¿Quién es el responsable?"
            };

            var indicadorList = new List<Indicador>();

            var count = 0;
            foreach (var item in indicadores)
            {
                count++;
                var indicador = new Indicador
                {
                    IndicadorId = count,
                    IndicadorNombre = item
                };

                indicadorList.Add(indicador);
            }

            var model= new ApoyoAlEstudianteModel
            {
                IndicadoresList = indicadorList.ToList()
            };

            return model;
        }

        public ApoyoAlEstudianteModel GetPreguntas()
        {
            string[] preguntas =
           {
                "¿Cuáles utilizan?",
                "¿Cómo lo hacen? Procedimiento",
                "¿Cuándo se hace? Periodicidad",
                "¿Quién es el responsable?"
            };

            var preguntasList = new List<Preguntas>();

            var count = 0;
            foreach (var item in preguntas)
            {
                count++;
                var pregunta = new Preguntas
                {
                    PreguntaId = count,
                    NombrePregunta = item
                };

                preguntasList.Add(pregunta);
            }

            var model = new ApoyoAlEstudianteModel
            {
                PreguntasList = preguntasList.ToList()
            };

            return model;
        }
    }
}
