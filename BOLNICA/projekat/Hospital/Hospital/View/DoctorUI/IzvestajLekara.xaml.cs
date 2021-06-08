using Hospital.Controller;
using MindFusion.Graphs;
using MindFusion.Pdf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzvestajLekara.xaml
    /// </summary>
    public partial class IzvestajLekara : Window
    {
        CheckupController controller = new CheckupController();
        PatientFileStorage storagePatient = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");

        public IzvestajLekara()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
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
                stringBuilder.Append("Prikazan je izvestaj pregleda pacijenta koji se odvio u periodu od ");
                //graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 180));
                stringBuilder = new StringBuilder("");
                stringBuilder.Append(Convert.ToDateTime(datePicker1.Text).ToString("dd.MM.yyyy.")).Append(" do ")
                    .Append(Convert.ToDateTime(datePicker2.Text).ToString("dd.MM.yyyy."));
                //graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 192));

                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                
                table.Columns.Add("Ime i prezime pacijenta");
                table.Columns.Add("Datum rodjenja pacijenta");
                table.Columns.Add("Opis");

                table.Rows.Add(new string[] { "Ime i prezime pacijenta", "Datum rodjenja pacijenta", "Opis" });

                String summary = "";

                foreach(Patient patient in storagePatient.GetAll())
                {
                    String name = patient.Name + " " + patient.Surname;
                    table.Rows.Add(new string[] {
                        name, patient.BirthdayDate.ToString(),
                        summary
                    });
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Draw(page, new PointF(0, 240));
                
                graphics.DrawString(stringBuilder.ToString(), font, PdfBrushes.Black, new PointF(28, 204));

                document.Save("./../../../../Hospital/reports/reportDoctor.pdf");
                document.Close(true);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
