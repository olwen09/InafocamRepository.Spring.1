using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ReportRepository : IReport
    {

        private readonly inafocam_tracingContext _context;

        public ReportRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll => _context.Report
            .Include(x => x.Usuario)
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.File)
            .Include(x => x.Status);

        public IEnumerable<Report> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId)
                .Where(x => x.Status.StatusName == "Activo");
        }

        public Report GetById(int reportId)
        {
           return  GetAll.FirstOrDefault(x => x.ReportId == reportId);
        }

        public void Save(Report model)
        {
            var now = DateTime.Now;
            var estadoActivo = 1;

           if(model.ReportId != 0)
            {
                model.UpgradeDate = now;

                _context.Report.Update(model);
            }
            else
            {

                model.StatusId = estadoActivo;
                model.CreationDate = now;
                _context.Add(model);
            }

            _context.SaveChanges();
        }

        public void DeleteReport(int reportId)
        {
           
            var  reportData = _context.Report.Find(reportId);
            reportData.StatusId = StatusValues.Eliminado;

            _context.Report.Update(reportData);


            _context.SaveChanges();
        }

       
    }
}
