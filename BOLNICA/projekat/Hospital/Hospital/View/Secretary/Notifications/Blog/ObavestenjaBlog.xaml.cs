using Hospital.Sekretar;
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

namespace Hospital.Model
{
    /// <summary>
    /// Interaction logic for ObavestenjaBlog.xaml
    /// </summary>
    public partial class ObavestenjaBlog : Window
    {

        public ObservableCollection<Notice> listNotice { get; set; }
        public ObavestenjaBlog()
        {
            InitializeComponent();
            this.DataContext = this;
            listNotice = loadJason();
        }
        public ObservableCollection<Notice> loadJason()
        {
            NoticeFileStorage pfs = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            ObservableCollection<Notice> rs = new ObservableCollection<Notice>(pfs.GetAll());
            return rs;

        }


    
        private void obrisi(object sender, RoutedEventArgs e)
        {
            if (textBlog.SelectedIndex != -1)
            {
                ObrisiObavestenjeBlog obrisi = new ObrisiObavestenjeBlog(listNotice, (Notice)textBlog.SelectedItem, textBlog.SelectedIndex);
                obrisi.Show();
            } else
            {
                MessageBox.Show("Niste izabrali obavestenje koje je potrebno obrisati!");
            }


        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            DodajObavestenjeBlog novo = new DodajObavestenjeBlog(listNotice);
            novo.Show();

        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
