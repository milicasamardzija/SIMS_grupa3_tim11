using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class CheckupDataBaseFactory : CheckupFactory
    {
        public ICheckupFileStorage CreateCheckup()
        {
            throw new NotImplementedException();
        }
       
        public ICheckupFileStorage SaveCheckup(CheckupDTO checkup)
        {
            throw new NotImplementedException();
        }
    }
}
