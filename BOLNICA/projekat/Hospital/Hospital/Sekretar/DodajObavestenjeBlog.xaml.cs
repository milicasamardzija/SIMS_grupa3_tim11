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
    
    public partial class DodajObavestenjeBlog : Window
    {
        public ObservableCollection<Notice> listN { get; set; }

        public NoticeFileStorage storage = new NoticeFileStorage();
        public ObservableCollection<Notice> myUpdate;
        public DodajObavestenjeBlog(ObservableCollection<Notice> list)
        {
            InitializeComponent();
            this.DataContext = this;
            listN = loadNotifications();
            myUpdate = list;
        }

        public int generisiId()
        {
            int ret = 1;

            NoticeFileStorage pfs = new NoticeFileStorage();
            ObservableCollection<Notice> all = pfs.GetAll();

            foreach (Notice nId in all)
            {
                foreach (Notice n in all)
                {
                    if (ret == n.id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }
        public ObservableCollection<Notice> loadNotifications()
        {
            NoticeFileStorage nf = new NoticeFileStorage();
            ObservableCollection<Notice> n = new ObservableCollection<Notice>(nf.GetAll());

            return n;

        }
        private void da(object sender, RoutedEventArgs e)
        {
            Notice n = new Notice(sadrzaj.Text, generisiId());
            storage.save(n);
          
            myUpdate.Add(n); //da se vidi da postoji
            this.Close();
            
        }
        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
