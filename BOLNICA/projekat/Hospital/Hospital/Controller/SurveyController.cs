using Hospital.DTO;
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

      

        public List<SurveyDTO> getAll()
        {
            List<SurveyDTO> surveys = new List<SurveyDTO>();
            foreach (Survey survey in service.getAll())
            {
                surveys.Add(new SurveyDTO(survey.mark,survey.comment,survey.idApp,survey.drname));
            }
            return surveys;
        }

        public void save(SurveyDTO survey)
        {
            service.save(new Survey(survey.mark,survey.comment,survey.idApp,survey.drname));
        }
    }

}
