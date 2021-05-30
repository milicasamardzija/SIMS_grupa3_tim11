using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Hospital.Model.Notification;
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

namespace Hospital
{
   
    public partial class BlogGlavni : Page
    {

       
        public ObservableCollection<Notice> listNotice { get; set; }

        public ObservableCollection<NoticeInteresting> listInteresting { get; set; }
        public BlogGlavni()
        {
            InitializeComponent();
            this.DataContext = this;
            listNotice= loadJason();
            listInteresting = loadJasonFileInteresting();
        }

        public ObservableCollection<Notice> loadJason()
        {
             NoticeFileStorage pfs = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            ObservableCollection<Notice> rs = new ObservableCollection<Notice>(pfs.GetAll());
            
              return rs;
          
        }

        public ObservableCollection<NoticeInteresting> loadJasonFileInteresting()
        {
            INoticeInterestingFileStorage storage = new NoticeInterestingFileStorage("./../../../../Hospital/files/noticesInteresting.json");
            ObservableCollection<NoticeInteresting> ni = new ObservableCollection<NoticeInteresting>(storage.GetAll());
            return ni;
        }

    }
}
