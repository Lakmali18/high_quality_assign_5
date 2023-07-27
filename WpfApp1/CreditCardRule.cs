using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ConsoleApp1;

namespace WpfApp1
{
    class CreditCardRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string creditCardNumber = (string) value;

            if ( (value == null) || !CreditCardHelper.IsCreditCardNumberValid(creditCardNumber))
            {
                return new ValidationResult(false, "Invalid credit card!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
