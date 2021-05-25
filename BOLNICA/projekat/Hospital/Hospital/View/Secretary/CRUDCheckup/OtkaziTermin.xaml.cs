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

    public partial class OtkaziTermin : Window
        
    {
        public ObservableCollection<Checkup> listCheckup;
        public int index;
        public int chId;
        public OtkaziTermin(ObservableCollection<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            chId = selectedCheckup.Id;
            index = selectedIndex;


        }

        private void YesBtn(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage cfs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            cfs.DeleteById(chId);
            listCheckup.RemoveAt(index);
            this.Close();

        }

        private void NoBtn(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
