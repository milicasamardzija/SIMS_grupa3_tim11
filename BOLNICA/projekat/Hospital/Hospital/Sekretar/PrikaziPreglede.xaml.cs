using Hospital.Model;
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
    
    public partial class PrikaziPreglede : Window
    {

       public  ObservableCollection<Checkup> listCheckups
        { 
            get;
            set; 
        }

       


        public PrikaziPreglede()
        {
            InitializeComponent();
            this.DataContext = this;
            listCheckups = loadJson();
            

        }

        private ObservableCollection<Checkup> loadJson()
        {
            CheckupFileStorage cfs = new CheckupFileStorage();
            ObservableCollection<Checkup> ch = new ObservableCollection<Checkup>(cfs.GetAll());
            return ch;

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            DodajPregled newCheckup = new DodajPregled();
            newCheckup.Show();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
