using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WebShop.Infrastructure;
using WebShop.Manager;
using WebShop.Model;

namespace WSView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomerManager customerManager;

        public MainWindow()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {

            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string password = Password.Password.GetHashedString();
            string confirmPassword = ConfirmPassword.Password.GetHashedString();


            if (password == confirmPassword)
                customerManager.CreateCustomer(new Customer
                {
                    ID = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    CustomerType = CustomerType.New,
                    Password = password
                });
        }
    }
}
