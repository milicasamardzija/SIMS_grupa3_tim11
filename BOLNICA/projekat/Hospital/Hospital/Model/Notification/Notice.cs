using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public  class Notice : Entity
    {

    public String notice { get; set; }
   // public int id;

    public Notice() { }

    public Notice(String text, int id) : base(id)
    {
        notice = text;
       
    }
    }

