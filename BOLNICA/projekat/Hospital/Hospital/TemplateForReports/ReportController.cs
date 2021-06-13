
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.TemplateForReports
{
    public class ReportController
    {
      
        public ManagerReportService managerReportService; 
        public ReportController()
        {
            managerReportService = new ManagerReportService();

        }


        public void CreateManagerReport(DateTime start, DateTime end)
        {
            PrintReport report = new ManagerReportService();
            report.generateReport(start, end);
        }

        public void CreateSecretaryReport(DateTime start, DateTime end)
        {
            PrintReport report = new SecretaryReportService();
            report.generateReport(start, end);
        }
        public void CreateDoctorReport(DateTime start, DateTime end)
        {
            PrintReport report = new DoctorReportService();
            report.generateReport(start, end);
        }
    }
}
