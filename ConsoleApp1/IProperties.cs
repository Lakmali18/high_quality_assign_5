using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void PropertyDelegate();
    public interface IProperties : IComparable<IProperties>
    {
        int HouseAge { get; set; }
        decimal HouseSize { get; set; }
        decimal PaddockSize { get; set; }
        string CreditCardNumber { get; set; }
        PropertyDelegate PropDel { get; set; }
        void CreateDesign();
        void EstimateWork();
        void ArrangeWorkers();

    }
}
