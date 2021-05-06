using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for AlergeniDodaj.xaml
    /// </summary>
    public partial class AlergeniDodaj : Page
    {
        public ObservableCollection<Alergens> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<Alergens> listSelectedAlergens
        {
            get;
            set;
        }
        public AlergeniDodaj()
        {
            InitializeComponent();
            this.DataContext = this;
            listAllAlergens = loadJasonAlergens();
            listSelectedAlergens = new ObservableCollection<Alergens>();
        }

        public ObservableCollection<Alergens> loadJasonAlergens()
        {
            AlergensFileStorage afs = new AlergensFileStorage();
            ObservableCollection<Alergens> ret = new ObservableCollection<Alergens>(afs.GetAll());

            return ret;
        }
       public void Button_Click(object sender, RoutedEventArgs e)
        {
            AlergensFileStorage afs = new AlergensFileStorage();

            listSelectedAlergens.Add((Alergens)svi.SelectedItem);
            listAllAlergens.Remove((Alergens)svi.SelectedItem);
        }
    }
}
