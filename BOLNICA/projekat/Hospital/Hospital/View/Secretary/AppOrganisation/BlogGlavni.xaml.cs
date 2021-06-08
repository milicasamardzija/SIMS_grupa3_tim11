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
        public ObservableCollection<Notice> listNoticeDoctor { get; set; }
        public BlogGlavni()
        {
            InitializeComponent();
            this.DataContext = this;
            listNotice= loadJason();
            listNoticeDoctor = loadNoticeDoctor();
        }

        public ObservableCollection<Notice> loadJason()
        {
             NoticeFileStorage pfs = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            ObservableCollection<Notice> rs = new ObservableCollection<Notice>(pfs.GetAll());
            
              return rs;
          
        }

        public ObservableCollection<Notice> loadNoticeDoctor()
        {
            NoticeFileStorage noticesDoctorStorage = new NoticeFileStorage(@"./../../../../Hospital/files/noticesDoctor.json");
            ObservableCollection<Notice> noticeDoctor = new ObservableCollection<Notice>(noticesDoctorStorage.GetAll());
            return noticeDoctor;
        }

    }
}
