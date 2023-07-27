using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public abstract class Properties : IProperties
    {
        private int houseAge;
        private decimal houseSize;
        private decimal paddokSize;
        private string creditCardNumber;
        private PropertyDelegate propDel = null;


        private string time;

        public Properties()
        {
            SetUpDelegate();

        }

        public Properties(int houseAge, decimal houseSize, decimal paddokSize, string creditCardNumber)
        {
            this.houseAge = houseAge;
            this.houseSize = houseSize;
            this.paddokSize = paddokSize;
            this.creditCardNumber = creditCardNumber;
            SetUpDelegate();

        }

        public int HouseAge { get => houseAge; set => houseAge = value; }
        public decimal HouseSize { get => houseSize; set => houseSize = value; }
        public decimal PaddockSize { get => paddokSize; set => paddokSize = value; }
        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }
        [XmlIgnore]

        public PropertyDelegate PropDel { get => propDel; set => propDel = value; }
        public string ViewCreditCard { get => ConcealedCreditCard(); }

        public string Time { get => time; set => time = value; }

        public void ArrangeWorkers()
        {
            Console.WriteLine("Workers have arranged.");
        }


        public abstract void CreateDesign();

        public abstract void CreditCardPayment();

        public void EstimateWork()
        {
            Console.WriteLine("Work estimated.");
        }

        public bool CheckCreditCard()
        {
            bool result = false;
            if (CreditCardNumber != null && CreditCardNumber != string.Empty)
            {
                char[] passArray = CreditCardNumber.ToCharArray();
                if (passArray.Length == 16)
                {
                    for (int i = 0; i < passArray.Length; i++)
                    {
                        if (char.IsDigit(passArray[i]))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }


                }
            }
            return result;
        }

        public string ConcealedCreditCard()
        {

            char[] passArray = CreditCardNumber.ToCharArray();
            for (int i = 4; i < 12; i++)
            {
                passArray[i] = 'X';
            }
            return new string(passArray);
        }


        public int CompareTo(IProperties other)
        {
            return houseSize.CompareTo(other.HouseSize);
        }

        public override string ToString()
        {

            return string.Format("has a {0} year(s) old house and house size is {1} sq. ft. and paddock size is {2} sq. ft. \nThe recored credit card number is {3}.", houseAge, houseSize, PaddockSize, ViewCreditCard);
        }

        private void SetUpDelegate()
        {
            propDel += ArrangeWorkers;
            propDel += EstimateWork;
            propDel += CreateDesign;

        }
    }
}
