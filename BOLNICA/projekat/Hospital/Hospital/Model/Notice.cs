using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public  class Notice
    {

    public String notice { get; set; }
    public int id;

    public Notice() { }

    public Notice(String text, int i)
    {
        notice = text;
        id = i;
    }
    }

