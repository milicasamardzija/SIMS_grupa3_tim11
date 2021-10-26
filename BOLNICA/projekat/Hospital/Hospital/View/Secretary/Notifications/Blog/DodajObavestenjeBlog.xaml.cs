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

        public NoticeFileStorage storage = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
        public ObservableCollection<Notice> myUpdate;
        public DodajObavestenjeBlog(ObservableCollection<Notice> list)
        {
            InitializeComponent();
            this.DataContext = this;
            listN = loadNotifications();
            myUpdate = list;
        }

        public int generateId()
        {
            int ret = 1;

            NoticeFileStorage pfs = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            List<Notice> all = pfs.GetAll();
            ObservableCollection<Notice> allNotices = new ObservableCollection<Notice>(all);

            foreach (Notice nId in all)
            {
                foreach (Notice n in allNotices)
                {
                    if (ret == n.Id)
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
            NoticeFileStorage nf = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            ObservableCollection<Notice> n = new ObservableCollection<Notice>(nf.GetAll());

            return n;

        }
        private void da(object sender, RoutedEventArgs e)
        {
            Notice n = new Notice(sadrzaj.Text, generateId());
            storage.Save(n);
          
            myUpdate.Add(n); //da se vidi da postoji
            this.Close();
            
        }
        private void Ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
