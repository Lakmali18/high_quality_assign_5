using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{

    public enum CustomerTypes { HouseOwner, BusinesseOwner, Farmer }

    [XmlRoot("CustomerList")]
    [XmlInclude(typeof(HouseOwner))]
    [XmlInclude(typeof(SmallBusinesseOwner))]
    [XmlInclude(typeof(Farmer))]

    public class PropertyList : IDisposable
    {
        private List<Properties> propertyList = null;

        [XmlArray("Customers")]
        [XmlArrayItem("Customer", typeof(Properties))]


        public List<Properties> ListProperty{ get => propertyList; set => propertyList = value; }

        public PropertyList()
        {
            ListProperty = new List<Properties>();
        }

        public void Add(Properties property)
        {
            ListProperty.Add(property);
        }


        public int Count()
        {
            return ListProperty.Count();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Sort()
        {
            ListProperty.Sort();
        }

        public void Clear()
        {
            ListProperty.Clear();
        }

        public Properties this[int i]
        {
            get { return ListProperty[i]; }
        }
    }
}
