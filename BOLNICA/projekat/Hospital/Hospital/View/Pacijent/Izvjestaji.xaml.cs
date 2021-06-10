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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Izvjestaji.xaml
    /// </summary>
    public partial class Izvjestaji : Page
    {
        public Izvjestaji()
        {
            InitializeComponent();
            Calendar.Days[0].Notes = "ampril 12:00h";
            Calendar.Days[2].Notes = "analgin 10:00h";
            Calendar.Days[3].Notes = "paracetamol 13:00h";
            Calendar.Days[10].Notes = "paracetamol 13:00h";
            Calendar.Days[5].Notes = "ampril 12:00h";
            Calendar.Days[8].Notes = "analgin 10:00h";
            Calendar.Days[13].Notes = "ampril 10:00h";
            Calendar.Days[16].Notes = "plavix 13:00h";

        }
    }
}
