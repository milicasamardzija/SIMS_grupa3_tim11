using Hospital.Sekretar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class CheckupController
    {
        private CheckupService service;

        public CheckupController()
        {
            service = new CheckupService();
        }
    }
}
