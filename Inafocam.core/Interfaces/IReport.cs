using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IReport
    {

        IEnumerable<Report> GetAll { get; }

        IEnumerable<Report> GetAllByTracingId(int tracingId);

        Report GetById(int reportId);

        void Save(Report model);


        void DeleteReport(int reportId);
    }
}
