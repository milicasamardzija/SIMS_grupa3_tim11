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
        private FeedbackService service ;
        public FeedbackController()
        {

            service = new FeedbackService();

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
