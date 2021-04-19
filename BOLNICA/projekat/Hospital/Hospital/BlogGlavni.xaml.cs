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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
   
    public partial class BlogGlavni : Page
    {

       
        
        public BlogGlavni()
        {
            InitializeComponent();
            obavestenjaText.SelectedText = loadJason();
        }

        public String loadJason()
        {
            NoticeFileStorage pfs = new NoticeFileStorage();
            List<Notice> rs = new List<Notice>(pfs.GetAll());
            String ret = rs[0].notice;
            return ret;
        }

    }
}
