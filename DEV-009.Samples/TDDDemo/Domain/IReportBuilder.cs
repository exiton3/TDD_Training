using System.Collections.Generic;

namespace Domain
{
    public interface IReportBuilder
    {
        IEnumerable<Report> BuildReports(int clientId);
        SpecialReport BuildSpecialReport();
    }
}