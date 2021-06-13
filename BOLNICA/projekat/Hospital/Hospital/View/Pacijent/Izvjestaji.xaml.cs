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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Izvjestaji.xaml
    /// </summary>
    public partial class Izvjestaji : Window
    {

        RecipeController controller;
        private PrintDialog _printDialog = new PrintDialog();
        int id;
        public Izvjestaji(int idP)
        {
            InitializeComponent();
            id = idP;
            controller = new RecipeController();
            calendarComponents();

            mjeseci.SelectionChanged += (o, e) => osvjeziPrikazKalendara();
            godine.SelectionChanged += (o, e) => osvjeziPrikazKalendara();

        }

        private void dodajNotes()
        {
            string str;
            foreach (Recipe r in controller.getbyId(id))
            {
                str = "Lek: " + r.description + "@" + "Vreme: " + r.beginning.ToShortTimeString();
                str = str.Replace("@", " " + Environment.NewLine);

                string boo = r.beginning.ToUniversalTime().ToString("MMMM");
                int th = DateTime.ParseExact(boo, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                if (mjeseci.SelectedIndex == (th - 1))

                {
                    kalendar.Days[(int)r.beginning.Day - 1].Notes = str;
                   ;
                }

            }
        }
        private void osvjeziPrikazKalendara()
        {
            if (godine.SelectedItem == null) return;
            if (mjeseci.SelectedItem == null) return;

            int year = (int)godine.SelectedItem;

            int month = mjeseci.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            kalendar.BuildCalendar(targetDate);

            dodajNotes();

        }

        public void calendarComponents()
        {
            List<string> mjesec = new List<string> { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust",
                                                                        "Septembar", "Oktobar", "Novembar", "Decembar" };
            mjeseci.ItemsSource = mjesec;

            for (int i = -50; i < 50; i++)
            {
                godine.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            godine.SelectedItem = DateTime.Today.Year;

            string startMonth = DateTime.Now.ToUniversalTime().ToString("MMMM");
            int newmnths = DateTime.ParseExact(startMonth, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
            mjeseci.SelectedIndex = newmnths - 1;

            dodajNotes();

         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnGenerisi.Visibility = Visibility.Hidden;
            _printDialog.PrintVisual(this, "Probamo izvještaj!");
        }
    }
}
