using System.Collections.Generic;

namespace Domain
{
    public interface IReportBuilder
    {
        IEnumerable<Report> BuildReports();
        SpecialReport BuildSpecialReport();
    }
}