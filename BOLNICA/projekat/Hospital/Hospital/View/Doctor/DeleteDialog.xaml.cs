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
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.FileStorage.Interfaces;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DeleteDialog.xaml
    /// </summary>
    public partial class DeleteDialog : Window
    {
        public List<Checkup> listCheckup;
        public int indexCheckup;
        public int idCheckup;
        public CheckupController controller = new CheckupController(); 

        public DeleteDialog(List<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            idCheckup = selectedCheckup.Id;
            indexCheckup = selectedIndex;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            controller.DeleteById(idCheckup);
            listCheckup.RemoveAt(indexCheckup);
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
