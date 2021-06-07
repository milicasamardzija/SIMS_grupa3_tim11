using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
   public class DoctorService
    {

        private IDoctorFileStorage doctorStorage;

        public DoctorService()
        {
            doctorStorage= new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");

        }


        public int brojZaposlenihPoSpecijalizaciji(String specijalizacija)
        {
            int count = 0;


            return count;
        }
    }
}
