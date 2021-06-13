using Hospital.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Drawing;
using System.Data;
using Hospital.TemplateForReports;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzvestajLekara.xaml
    /// </summary>
    public partial class IzvestajLekara : Window
    {
        private ReportController controller;

        public IzvestajLekara()
        {
            InitializeComponent();

            controller = new ReportController();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
<<<<<<< Updated upstream

        {   controller.CreateDoctorReport((DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);
=======
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                Syncfusion.Pdf.Graphics.PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6);

                font = new PdfStandardFont(PdfFontFamily.Helvetica, 18);
                graphics.DrawString("Izvestaj o ", font, PdfBrushes.Black, new System.Drawing.PointF(170, 100));
                graphics.DrawString("pregledu stanja pacijenta", font, PdfBrushes.Black, new System.Drawing.PointF(112, 120));

                font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
                StringBuilder stringBuilder = new StringBuilder("");
                stringBuilder.Append("Prikazan je izvestaj pregleda pacijenata koji se odvio u periodu od ");
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 180));
                stringBuilder = new StringBuilder("");
                stringBuilder.Append(Convert.ToDateTime(datePicker1.Text).ToString("dd.MM.yyyy.")).Append(" do ")
                    .Append(Convert.ToDateTime(datePicker2.Text).ToString("dd.MM.yyyy."));
                
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();

                table.Columns.Add("Ime i prezime pacijenta");
                table.Columns.Add("Datum rodjenja pacijenta");
                
                table.Rows.Add(new string[] { "Ime i prezime pacijenta", "Datum rodjenja pacijenta"});

                foreach (Patient patient in storagePatient.GetAll())
                {
                    String name = patient.Name + " " + patient.Surname;
                    table.Rows.Add(new string[] {
                        name, patient.BirthdayDate.ToString(),
                    });
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Draw(page, new PointF(0, 240));
>>>>>>> Stashed changes


           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
