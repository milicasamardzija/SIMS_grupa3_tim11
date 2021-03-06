using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.ValidationManager
{
    class StringToDouble : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;

                if (s.Length == 0)
                {
                    return new ValidationResult(false, $"Polje ne sme biti prazno.");
                }

                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }

                return new ValidationResult(false, "Unesite brojnu vrednost.");
            }
            catch
            {
                return new ValidationResult(false, "");
            }
        }
    }
}
