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
    /// <summary>
    /// Interaction logic for ObrisiPregled.xaml
    /// </summary>
    public partial class ObrisiPregled : Window
    {
        public ObservableCollection<Checkup> listCheckup;
        public int index;
        public int id;
       
      

        public ObrisiPregled(ObservableCollection<Checkup> list, Checkup selected, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            id = selected.Id;
            index = selectedIndex;
        }

   

        private void yesBtn(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            st.DeleteById(id);
            listCheckup.RemoveAt(index);
            this.Close();
        }
        private void nobtn(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
