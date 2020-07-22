using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IResultsFromThePreviousPeriod
    {
        IEnumerable<ResultsFromThePreviousPeriod> GetAll { get; }


        public IEnumerable<ResultsFromThePreviousPeriod> GetAllByTracingId(int tracingId);
        void Save(ResultsFromThePreviousPeriod model);
    }
}
