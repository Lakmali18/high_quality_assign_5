using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using ConsoleApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyProperties> displayProperties = null;
        PropertyList propertyList = new PropertyList();
        MyProperties myProperty = new MyProperties();
        string[] customerType = null;

        public ObservableCollection<MyProperties> DisplayProps { get => displayProperties; set => displayProperties = value; }
        public MyProperties MyProperty { get => myProperty; set => myProperty = value; }
        public string[] CustomerType { get => customerType; set => customerType = value; }

        public MainWindow()
        {
            InitializeComponent();
            customerType = Enum.GetNames(typeof(CustomerTypes));
            DisplayProps = new ObservableCollection<MyProperties>();
            DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression beAge = BindingOperations.GetBindingExpression(txtAge, TextBox.TextProperty);
            BindingExpression beHouseSize = BindingOperations.GetBindingExpression(txtHouseSize, TextBox.TextProperty);
            BindingExpression bePaddockSize = BindingOperations.GetBindingExpression(txtPadockSize, TextBox.TextProperty);
            BindingExpression beCreditCardNo = BindingOperations.GetBindingExpression(txtCreditCard, TextBox.TextProperty);

            if (beAge.HasError || beHouseSize.HasError || bePaddockSize.HasError || beCreditCardNo.HasError)
            {
                return;
            }

            bool result = true;
            bool isValidAge = int.TryParse(txtAge.Text, out int age);
            bool isValidHouseSize = decimal.TryParse(txtHouseSize.Text, out decimal houseSize);
            bool isValidPaddockSize = decimal.TryParse(txtPadockSize.Text, out decimal paddockSize);

            string obscuredCreditCard = CreditCardHelper.ObscureCreditCardNumber(txtCreditCard.Text);
            MyProperties myProperties = new MyProperties();
            myProperties.HouseAge = age;
            myProperties.HouseSize = houseSize;
            myProperties.PaddockSize = paddockSize;
            myProperties.CreditCardNumber = obscuredCreditCard;
            myProperties.Type = (string) cmbType.SelectedValue;

            if (result && isValidAge && isValidHouseSize && isValidPaddockSize)
            {
                Properties properties = null;
                switch (cmbType.SelectedIndex)
                {
                    case 0:
                        properties = new HouseOwner(age, houseSize, paddockSize, obscuredCreditCard);
                        break;
                    case 1:
                        properties = new BusinessOwner(age, houseSize, paddockSize, obscuredCreditCard);
                        break;
                    case 2:
                        properties = new Farmer(age, houseSize, paddockSize, obscuredCreditCard);
                        break;
                    default:
                        MessageBox.Show("Program Error");
                        return;
                }
                myProperties.InnerProps = properties;
                DisplayProps.Add(myProperties);
                cmbType.SelectedIndex = -1;
                txtAge.Text = string.Empty;
                txtHouseSize.Text = string.Empty;
                txtPadockSize.Text = string.Empty;
                txtCreditCard.Text = string.Empty;
            }
        }
        private void WriteToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PropertyList));
            TextWriter tw = new StreamWriter("customer_info.xml");
            serializer.Serialize(tw, propertyList);
            tw.Close();
        }
        private void ReadFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PropertyList));
            TextReader tr = new StreamReader("customer_info.xml");
            propertyList = (PropertyList) serializer.Deserialize(tr);
            tr.Close();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            propertyList.Clear();
            ReadFromFile();
            DisplayProps.Clear();
            for (int i = 0; i < propertyList.Count(); i++)
            {
                Properties properties = propertyList[i];
                MyProperties newProperties = new MyProperties();
                newProperties.HouseAge = properties.HouseAge;
                newProperties.HouseSize = properties.HouseSize;
                newProperties.PaddockSize = properties.PaddockSize;
                newProperties.CreditCardNumber = properties.CreditCardNumber;

                string[] arrStr = properties.GetType().ToString().Split('.');
                string fullType = arrStr[arrStr.Length - 1];
                newProperties.Type = fullType.Substring(0, fullType.Length);
                DisplayProps.Add(newProperties);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            propertyList.Clear();
            foreach (MyProperties props in DisplayProps)
            {
                propertyList.Add(props.InnerProps);
            }
            WriteToFile();
        }

        private void txtCreditCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCreditCard.Foreground = Brushes.Black;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = from properties in DisplayProps
                        where properties.HouseAge.ToString().ToLower() == txtSearch.Text.ToLower().Trim()
                        select properties;
            MyGrid.ItemsSource = query;
        }
    }
}
