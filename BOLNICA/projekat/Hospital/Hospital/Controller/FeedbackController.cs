using Hospital.FileStorage;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
   public  class FeedbackController
    {
        private FeedbackService service;
        public FeedbackController()
        {

            service = new FeedbackService(new FeedbackFileStorage("./../../../../Hospital/files/storageFeedback.json"));

        }

        public void createFeedbackUtisak(Feedback feedback )
        {
            service.createFeedbackUtisak(feedback);
        }

        public void createFeedbackProblem(Feedback feedback)
        {
            service.createFeedbackProblem(feedback);
        }
    }
}
