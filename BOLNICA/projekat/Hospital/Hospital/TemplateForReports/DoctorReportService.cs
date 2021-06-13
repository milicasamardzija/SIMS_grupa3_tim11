using Hospital.Service;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.TemplateForReports
{
    public class DoctorReportService : PrintReport
    {

        public PatientService service =new  PatientService();
        public override void CreateDocument(DateTime start, DateTime finish)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                Syncfusion.Pdf.Graphics.PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6);

                string pocetak = start.ToString("dd.MM.yyyy.");
                string kraj = finish.ToString("dd.MM.yyyy.");


                font = new PdfStandardFont(PdfFontFamily.Helvetica, 18);
                graphics.DrawString("Izvestaj o ", font, PdfBrushes.Black, new System.Drawing.PointF(170, 100));
                graphics.DrawString("pregledu stanja pacijenta", font, PdfBrushes.Black, new System.Drawing.PointF(112, 120));

                font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
                StringBuilder stringBuilder = new StringBuilder("");
                stringBuilder.Append("Prikazan je izvestaj pregleda pacijenata koji se odvio u periodu od ");
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 180));
                stringBuilder = new StringBuilder("");
                stringBuilder.Append(pocetak).Append(" do ")
                    .Append(kraj);

                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();

                table.Columns.Add("Ime i prezime pacijenta");
                table.Columns.Add("Datum rodjenja pacijenta");

                table.Rows.Add(new string[] { "Ime i prezime pacijenta", "Datum rodjenja pacijenta" });



                foreach (Patient patient in service.getAll())
                {
                    String name = patient.Name + " " + patient.Surname;
                    table.Rows.Add(new string[] {
                        name, patient.BirthdayDate.ToString(),
                    });
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Draw(page, new PointF(0, 240));

                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 204));

                document.Save("./../../../../Hospital/reports/reportDoctor.pdf");
                document.Close(true);
            }
        }

        public override void PrintNote()
        {
            MessageBox.Show("Izvestaj lekara uspesno kreiran!");
        }

        public override void SaveReport()
        {
           // throw new NotImplementedException();
        }
    }

   
  
}
