using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class FeedbackFileStorage : GenericFileStorage<Feedback>, IFeedbackFileStorage
    {
        public FeedbackFileStorage(String filePath) : base(filePath) { }
    }
}
