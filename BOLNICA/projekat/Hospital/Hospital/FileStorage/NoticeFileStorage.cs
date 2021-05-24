using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;



    public class NoticeFileStorage : GenericFileStorage<Notice>, INoticeFileStorage
    {
    public NoticeFileStorage(String filePath) : base(filePath) { }


}
