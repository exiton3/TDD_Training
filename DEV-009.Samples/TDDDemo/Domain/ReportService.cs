using System.Linq;

namespace Domain
{
    public class ReportService
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;

        public ReportService(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            _reportBuilder = reportBuilder;
            _reportSender = reportSender;
        }

        public int SendReports()
        {
            var reports = _reportBuilder.BuildReports().ToList();
            var specialReport = _reportBuilder.BuildSpecialReport();
            if (reports.Count == 0)
            {
                _reportSender.Send(specialReport);

            }
            else
            {
                foreach (var report in reports)
                {
                    _reportSender.Send(report);
                }
            }
          
            return  reports.Count;
        }
    }
}