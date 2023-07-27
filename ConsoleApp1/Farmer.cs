using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Farmer : Properties
    {
        public Farmer() { }

        public Farmer(int houseAge, decimal houseSize, decimal paddockSizze, string creditCardNo) : base(houseAge, houseSize, paddockSizze, creditCardNo)
        {

        }

        public override void CreateDesign()
        {
            Console.WriteLine("Grain storage areas were designed.");
        }

        public override void CreditCardPayment()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return string.Format("Farmer {0}", base.ToString());
        }
    }
}
