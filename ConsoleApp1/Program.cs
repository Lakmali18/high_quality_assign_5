using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public enum CustomerTypes
        {
            HouseOwners = 1,
            BusinessOwners = 2,
            Farmers = 3
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Go();

        }

        public void Go()
        {

            using (PropertyList nl = new PropertyList())
            {
                HouseOwner blt = new HouseOwner(10, 200, 150,"8986987878765676");
                nl.Add(blt);
                BusinessOwner et = new BusinessOwner(30, 250, 200, "6709878905676787");
                nl.Add(et);
                Farmer ft = new Farmer(50, 350, 250, "6767545454656766");
                nl.Add(ft);
                nl.Sort();
                for (int i = 0; i < nl.Count(); i++)
                {
                    Console.WriteLine(nl[i]);
                   // Console.WriteLine("Tree #{0}", i + 1);
                    nl[i].PropDel();
                }
            }

        }
    }
}
