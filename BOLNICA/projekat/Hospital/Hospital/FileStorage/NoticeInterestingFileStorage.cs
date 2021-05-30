using Hospital.FileStorage.Interfaces;
using Hospital.Model.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class NoticeInterestingFileStorage : GenericFileStorage<NoticeInteresting>, INoticeInterestingFileStorage
    {
        public NoticeInterestingFileStorage(string filePath) : base(filePath)
        {
        }
    }
}
