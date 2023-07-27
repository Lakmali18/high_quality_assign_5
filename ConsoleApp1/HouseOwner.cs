using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HouseOwner : Properties
    {
        public HouseOwner() { }

        public HouseOwner(int houseAge, decimal houseSize, decimal paddockSizze, string creditCardNo) : base(houseAge, houseSize, paddockSizze, creditCardNo)
        {

        }

        public override void CreateDesign()
        {
            Console.WriteLine("Sun rooms were designed.");
        }

        public override void CreditCardPayment()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("House owner {0}", base.ToString());
        }
    }
}
