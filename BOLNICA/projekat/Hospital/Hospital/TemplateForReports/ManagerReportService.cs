using Hospital.Controller;
using Hospital.Model;
using Hospital.Service;
using Hospital.View.Manager.Zaposleni;
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
using System.Windows.Controls;

namespace Hospital.TemplateForReports
{
    public class ManagerReportService : PrintReport
    {

      

        public DoctorService doctorService = new DoctorService();
        public CheckupService checkupService = new CheckupService();
        public PdfDocument document = new PdfDocument();
        public override void CreateDocument(DateTime start, DateTime finish)
        {
           // using (PdfDocument document = new PdfDocument())
        
                PdfPage page = document.Pages.Add();

                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6);

            string pocetak = start.ToString("dd.MM.yyyy.");
            string kraj = finish.ToString("dd.MM.yyyy.");

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
                graphics.DrawString("Izveštaj o zauzetosti", font, PdfBrushes.Black, new PointF(170, 100));
                graphics.DrawString("lekara za odredjeni vremenski period", font, PdfBrushes.Black, new PointF(112, 120));


                // SADRZAJ
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
                StringBuilder stringBuilder = new StringBuilder("");
                stringBuilder.Append("U sledecoj tabeli prikazani su doktori nase bolnice i broj pregleda, operacija i kontrola koje su obavili u periodu od ");
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 180));
                stringBuilder = new StringBuilder("");
                stringBuilder.Append(pocetak);
                stringBuilder.Append(" do ");
                stringBuilder.Append(kraj);
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 192));


                // TABELA
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();

                //Include columns to the DataTable.
                table.Columns.Add("Ime i prezime lekara");
                table.Columns.Add("specijalizacija");
                table.Columns.Add("Broj obavljenih pregleda");
                table.Columns.Add("Broj obavljenih operacija");
                table.Columns.Add("Broj obavljenih kontrola");


                table.Rows.Add(new string[] { "Ime i prezime lekara", "Specijalizacija", "Broj obavljenih pregleda", "Broj obavljenih operacija", "Broj obavljenih kontrola" });

                double hours = 0;
                int examinationsSum = 0;
                int operationsSum = 0;
                int controlsSum = 0;
                foreach (Doctor doctor in doctorService.getAll())
                {
                    String name = doctor.Name + " " + doctor.Surname;
                    int examinations = 0;
                    int operations = 0;
                    int controls = 0;

                    List<Checkup> checkupsByDoctor = checkupService.getCheckupDoctorsAndTime(start, finish, doctor.Id);
                    foreach (Checkup checkup in checkupsByDoctor)
                    {
                        if (checkup.Type.Equals(CheckupType.pregled))
                        {
                            hours += checkup.Duration;
                            examinations++;
                            examinationsSum++;
                        }
                        else if (checkup.Type.Equals(CheckupType.operacija))
                        {
                            hours += checkup.Duration;
                            operations++;
                            operationsSum++;
                        }
                        else if (checkup.Type.Equals(CheckupType.kontrola))
                        {
                            hours += checkup.Duration;
                            controls++;
                            controlsSum++;
                        }
                    }
                    table.Rows.Add(new string[] {name,
                        doctor.SpecializationType.ToString(),
                        Convert.ToString(examinations),
                        Convert.ToString(operations),
                        Convert.ToString(controls)
                    });
                }


                pdfLightTable.DataSource = table;
                pdfLightTable.Draw(page, new PointF(0, 240));

                stringBuilder = new StringBuilder("");
                stringBuilder.Append("Na nivou citave bolnice, u ovom vremenskom periodu, obavljeno je ").Append(examinationsSum.ToString()).Append
                    (" pregleda, ").Append(operationsSum.ToString()).Append(" operacija, ").Append(controlsSum.ToString())
                    .Append(" kontolnih").Append(" pregleda.");
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 204));

           
           document.Save("./../../../../Hospital/reports/reportManager.pdf");
         document.Close(true);
          
        }

        public override void PrintNote()
        {
            MessageBox.Show("Izvestaj o zauzetosti lekara je kreiran!");
        }

        public override void SaveReport()
        {
           
        }


       

    }
}
