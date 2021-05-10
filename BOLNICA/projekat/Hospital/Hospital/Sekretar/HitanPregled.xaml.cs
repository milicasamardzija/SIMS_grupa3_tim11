using Hospital.Model;
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

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for HitanPregled.xaml
    /// </summary>
    public partial class HitanPregled : Window
    {
        public HitanPregled()
        {
            InitializeComponent();
            dodajSpecijalizacije();
        }

        public void dodajSpecijalizacije()
        {

            specializationCb.ItemsSource = Enum.GetValues(typeof(SpecializationType));

        }
    }
}
