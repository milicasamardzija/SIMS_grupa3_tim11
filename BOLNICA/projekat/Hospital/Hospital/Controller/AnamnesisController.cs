using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class AnamnesisController
    {
        private AnamnesisService service;

        public AnamnesisController()
        {
            service = new AnamnesisService();
        }

        public List<Anamnesis> getAll()
        {
            List<Anamnesis> allAnamnesis = new List<Anamnesis>(service.getAll());
            List<Anamnesis> anamnesis = new List<Anamnesis>();
            foreach(Anamnesis a in allAnamnesis)
            {
                Anamnesis newAnamnesis = new Anamnesis(a.Id, a.nameS, a.gender, a.idPatient, a.adress,
                    a.status, a.job, a.summary);
            }
            return anamnesis;
        }
    }
}
