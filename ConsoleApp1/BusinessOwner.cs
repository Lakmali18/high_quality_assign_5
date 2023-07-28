using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BusinessOwner : Properties
    {
        public BusinessOwner() { }

        public BusinessOwner(int houseAge, decimal houseSize, decimal paddockSizze, string creditCardNo) : base(houseAge, houseSize, paddockSizze, creditCardNo)
        {

        }

        public override void CreateDesign()
        {
            Console.WriteLine("Customer lobbies were designed.");
        }

        public override void CreditCardPayment()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Business owner {0}", base.ToString());
        }

    }
}
