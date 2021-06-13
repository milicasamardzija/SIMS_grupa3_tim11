using Hospital.Service;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.TemplateForReports
{
    public class SecretaryReportService : PrintReport
    {

        private CheckupService service= new CheckupService();
        public override void CreateDocument(DateTime start, DateTime finish)
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6);

            // HEADER
            graphics.DrawString("Adresa: Bore Tirica 5", font, PdfBrushes.Black, new PointF(0, 19));
            graphics.DrawString("21000 Novi Sad, Srbija", font, PdfBrushes.Black, new PointF(0, 26));
            graphics.DrawString("Kontakt telefon: 0218974452", font, PdfBrushes.Black, new PointF(0, 33));
            graphics.DrawString("E-mail adresa: zdravobolnica@gmail.com", font, PdfBrushes.Black, new PointF(0, 40));


            // SLIKA
            PdfImage image = PdfImage.FromFile("./../../../../Hospital/Hospital/View/Images/logo-removebg-preview.png");
            RectangleF bounds = new RectangleF(345, 12, 150, 50);
            page.Graphics.DrawImage(image, bounds);

            // NASLOV
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 17);
            graphics.DrawString("Izveštaj o broju operacija i pregleda ", font, PdfBrushes.Black, new PointF(170, 100));
            graphics.DrawString("                 za odredjeni vremenski period", font, PdfBrushes.Black, new PointF(112, 120));


            //logika za izracunavanje
            int operations = service.counterOperation(start, finish);
            int checkups = service.counterCheckup(start, finish);

            string pocetak = start.ToString("dd.MM.yyyy.");
            string kraj = finish.ToString("dd.MM.yyyy.");


            font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
            StringBuilder stringBuilder = new StringBuilder("");

            stringBuilder.Append("U proteklom periodu od   " + pocetak + "   do   " + kraj + " : ");
            graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 180));
            stringBuilder = new StringBuilder("");
         
            stringBuilder.Append(" Broj zakazanih OPERACIJA je  ");
            stringBuilder.Append(operations + ", a broj zakazanih PREGLEDA je  " + checkups );
            stringBuilder.Append("\n\n");
            stringBuilder.Append( " Hvala Vam sto se odlucujete bas za nas!  ");
            graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 192));

            document.Save("./../../../../Hospital/reports/reportSecretary.pdf");
            document.Close(true);
        }

        public override void PrintNote()
        {
            MessageBox.Show("Izvestaj o broju operacija i pregleda je kreiran!");
        }

        public override void SaveReport()
        {
           
        }
    }
}
