using MindFusion.Pdf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PdfGraphics = Syncfusion.Pdf.Graphics.PdfGraphics;

namespace Hospital.TemplateForReports
{
    public abstract class PrintReport
    {
   

        public abstract void CreateDocument(DateTime start, DateTime finish);

      
        public abstract void SaveReport();
        public abstract void PrintNote();

        //ova metoda se ne menja, uvek mora ovako da izgleda
        public  void generateReport(DateTime dateStart, DateTime dateEnd)
        {
            CreateDocument(dateStart, dateEnd);
     
            SaveReport();
            PrintNote();

        }

        
    }
}
