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
    /// Interaction logic for Izvjestaj.xaml
    /// </summary>
    public partial class Izvjestaj : Window
    {
        public Izvjestaj()
        {
            InitializeComponent();
            Calendar.Days[0].Notes = "ampril 08:00";
        }
       

        private void Calendar_DayChanged(object sender, MyCalendar.Calendar.DayChangedEventArgs e)
        {
            Console.WriteLine("Pozvana metoda daychanged");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // Calendar.Days[0].Notes = "Ovo se dodalo.";
           // Calendar.Days[0].Enabled = false;
        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Pozvana metoda double");
        }
    }
}
