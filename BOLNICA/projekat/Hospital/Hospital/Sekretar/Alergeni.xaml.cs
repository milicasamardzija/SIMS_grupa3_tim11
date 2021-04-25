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
using System.Windows.Shapes;

namespace Hospital.Sekretar
{
    public partial class Alergeni : Window
    {

        public ObservableCollection<Alergens> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<Alergens> listAlergens
        {
            get;
            set;
        }
        public Alergeni()
        {
            InitializeComponent();
            this.DataContext = this;
            listAllAlergens = loadJason();
        }

        public ObservableCollection<Alergens> loadJason()
        {
            AlergensFileStorage afs = new AlergensFileStorage();
           // ObservableCollection<Alergens> a = new ObservableCollection<Alergens>();
            ObservableCollection<Alergens> ret = new ObservableCollection<Alergens>(afs.GetAll());

            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
