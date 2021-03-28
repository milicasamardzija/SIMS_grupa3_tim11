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
using System.IO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        public ObservableCollection<Checkup> CheckupList
        {
            get;
            set;
        }

        public Pregled()
        {
            InitializeComponent();
            this.DataContext = this;
            CheckupList = loadJson();
        }

        public ObservableCollection<Checkup> loadJson()
        {
            CheckupFileStorage cs = new CheckupFileStorage();
            ObservableCollection<Checkup> cc = new ObservableCollection<Checkup>(cs.GetAll());
            return cc;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog ad = new AddDialog(CheckupList);
            ad.Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditDialog ed = new EditDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            ed.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog dd = new DeleteDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            dd.Show();
        }
    }
}
