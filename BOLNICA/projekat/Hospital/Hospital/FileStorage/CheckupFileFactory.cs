using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class CheckupFileFactory : CheckupFactory
    {
        private CheckupFileStorage checkupFileStorage;

        public ICheckupFileStorage CreateCheckup()
        {
            if(checkupFileStorage == null)
            {
                checkupFileStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            }
            return checkupFileStorage;
        }

        public ICheckupFileStorage SaveCheckup(CheckupDTO checkup)
        {
            return checkupFileStorage.Save(checkup);
        }
        
    }
}
