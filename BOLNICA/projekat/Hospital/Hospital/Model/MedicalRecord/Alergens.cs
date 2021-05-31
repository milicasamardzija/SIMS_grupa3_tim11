using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Alergens : Entity, INotifyPropertyChanged
    {
    private String name;
    private String code;
   

    public event PropertyChangedEventHandler PropertyChanged;

    public Alergens() { }

    public Alergens(String n, String c)  {
        this.name = n;
        this.code = c;
        this.Id = 0;
    }

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

