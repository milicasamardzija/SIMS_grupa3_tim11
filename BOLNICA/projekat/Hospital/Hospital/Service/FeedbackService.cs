using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
     public class FeedbackService
    {

        private IFeedbackFileStorage storage;

        public FeedbackService(IFeedbackFileStorage storage)
        {
            this.storage = storage;
        }
        public int generateId()
        {
            int ret = 0;
            List<Feedback> all = storage.GetAll();

            foreach (Feedback patient in all)
            {
                foreach (Feedback p in all) { 
                    if (ret == p.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        internal void createFeedbackProblem(Feedback feedback)
        {
            Feedback newFeedback = new Feedback(generateId(), FeedbackType.prijava_problema, feedback.grade, feedback.comment, feedback.problem,feedback.email);
            storage.Save(newFeedback);
        }

        public void createFeedbackUtisak(Feedback feedback)
        {
            Feedback newFeedback = new Feedback(generateId(), FeedbackType.utisak, feedback.grade, feedback.comment);
            storage.Save(newFeedback);
        }
    }
}
