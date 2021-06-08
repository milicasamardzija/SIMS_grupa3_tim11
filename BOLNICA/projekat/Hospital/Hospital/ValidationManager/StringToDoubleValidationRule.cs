using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.ValidationManager
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;

                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite ");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class MinMaxValidationRule : ValidationRule
    {
        public int Min
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is int)
            {
                int d = (int)value;
                if (d < Min) return new ValidationResult(false, "Value too small.");
                if (d > Max) return new ValidationResult(false, "Value too large.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
