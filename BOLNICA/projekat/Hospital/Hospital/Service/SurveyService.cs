using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class SurveyService
    {
        private SurveyFileStorage surveyFileStorage;

        public SurveyService()
        {

            surveyFileStorage = new SurveyFileStorage("./../../../../Hospital/files/ankete.json");
        }
        public void save(Survey survey)
        {
            surveyFileStorage.Save(survey);
        }

        public List<Survey> getAll()
        {
            return surveyFileStorage.GetAll();
        }
    }
}
