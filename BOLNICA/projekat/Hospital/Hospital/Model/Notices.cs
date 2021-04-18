using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

//namespace Hospital.Model

  
   public class Notices 
    {

        public String notice { get; set; }

        public Notices() { }
        public Notices(String text)
        {
            notice = text;
        }
        

    }
   

