using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Notification
{
    public class NoticeInteresting : Entity
    {
        public String noticeInteresting { get; set; }

        public NoticeInteresting() { }

        public NoticeInteresting(String note, int id) : base(id)
        {
            noticeInteresting = note;
        }
    }
}
