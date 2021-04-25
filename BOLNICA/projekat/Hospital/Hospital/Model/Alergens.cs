using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Alergens
    {
    public String name;
    public String code;

    //nisam sigurna mora li ovako ?
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public String Name
    {
        get
        {
            return name;
        }
        set
        {
            if(value != name)
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }

    public String  Code
    {
        get
        {
            return code;
        }
        set
        {
            if (value != code)
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
    }

}

