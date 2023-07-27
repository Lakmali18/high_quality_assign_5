using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    internal class SizeRule : ValidationRule
    {
        decimal min;
        decimal max;

        public decimal Min { get => min; set => min = value; }
        public decimal Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numVal = 0;
            if (!int.TryParse(value.ToString(), out numVal))
            {
                return new ValidationResult(false, "Wrong data");
            }

            if (numVal <= min || numVal > max)
            {
                return new ValidationResult(false, "Out of Range");
            }

            return ValidationResult.ValidResult;
        }
    }
}

