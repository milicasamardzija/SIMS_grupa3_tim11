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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for UpravljanjeBlogom.xaml
    /// </summary>
    public partial class UpravljanjeBlogom : Window
    {
        public ObservableCollection<Notice> listNoticeDoctor { get; set; }
        public Notice notice;
        public int index;

        public UpravljanjeBlogom(ObservableCollection<Notice> list, int indexNotice)
        {
            InitializeComponent();
            listNoticeDoctor = list;
            index = indexNotice;
        }

        public int generateNoticeId()
        {
            int val = 0;
            NoticeFileStorage noticeStorage = new NoticeFileStorage("./../../../../Hospital/files/noticesDoctor.json");
            List<Notice> allNotices = new List<Notice>();
            allNotices = noticeStorage.GetAll();

            foreach (Notice id in allNotices)
            {
                foreach (Notice n in allNotices)
                {
                    if (val == n.Id)
                    {
                        ++val; //proveravam sledeci slobodan broj
                        break;
                    }
                }
            }
            return val;
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NoticeFileStorage storageNotice = new NoticeFileStorage(@"./../../../../Hospital/files/noticesDoctor.json");
            Notice newNotice = new Notice(Convert.ToString(textBox.Text), generateNoticeId());
            storageNotice.Save(newNotice);
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
