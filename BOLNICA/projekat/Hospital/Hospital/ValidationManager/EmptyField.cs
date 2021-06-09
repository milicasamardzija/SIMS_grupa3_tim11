using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.ValidationManager
{
    class EmptyField : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                if (s.Length == 0)
                {
                    return new ValidationResult(false, $"Polje ne sme biti prazno.");
                }
              
                if (!string.IsNullOrEmpty(s))
                {
                    return new ValidationResult(true, null);
                }

                return new ValidationResult(false, "Morate uneti vrednost.");
            }
            catch
            {
                return new ValidationResult(false, "");
            }
        }
    }
}
