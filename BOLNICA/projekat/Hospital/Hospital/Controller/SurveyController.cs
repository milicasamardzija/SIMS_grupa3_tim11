using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class SurveyController
    {

        private SurveyService service = new SurveyService();



        public List<Survey> getAll()
        {
            List<Survey> surveys = new List<Survey>();
            foreach (Survey survey in service.getAll())
            {
                surveys.Add(new Survey(survey.mark, survey.comment, survey.idApp, survey.drname));
            }
            return surveys;
        }

        public void save(Survey survey)
        {
            service.save(survey);
        }
    }

}