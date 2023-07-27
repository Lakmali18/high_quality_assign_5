using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace WpfApp1
{
    public class MyProperties : Properties
    {
        string type;
        int intType;
        Properties innerProps;

        public string Type { get => type; set => type = value; }
        public Properties InnerProps { get => innerProps; set => innerProps = value; }
        public int IntType { get => intType; set => intType = value; }

        public override void CreateDesign()
        {
            throw new NotImplementedException();
        }

        public override void CreditCardPayment()
        {
            throw new NotImplementedException();
        }
    }
}
