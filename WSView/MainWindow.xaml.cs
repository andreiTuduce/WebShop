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
using WSView.Manager;
using WSView.Model;
using WSView.View;
using WSView.View.Helper;

namespace WSView
{
    public partial class MainWindow : Window
    {
        private readonly RegistrationView registrationView;

        public MainWindow()
        {
            InitializeComponent();
            registrationView = new RegistrationView();
        }

        private void AddControl(object sender, RoutedEventArgs e)
        {

            (TextBox[] textBoxes, PasswordBox[] passwordBoxes) = registrationView.ChangeViewToRegistration();

            foreach (TextBox textBox in textBoxes)
            {
                MainGrid.Children.Add(textBox);

            }

            foreach (PasswordBox passwordBox in passwordBoxes)
            {
                MainGrid.Children.Add(passwordBox);
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer { ID = Guid.NewGuid(), CustomerType = CustomerType.New };

            string password = string.Empty;
            string confirmPassword = string.Empty;

            foreach (UIElement element in MainGrid.Children)
            {
                TextBox textBox = element as TextBox;

                if (textBox != null)

                    switch (textBox.Name)
                    {
                        case TextBoxHelper.FirstName:
                            customer.FirstName = textBox.Text;
                            break;
                        case TextBoxHelper.LastName:
                            customer.LastName = textBox.Text;
                            break;
                        case TextBoxHelper.Username:
                            customer.Username = textBox.Text;
                            break;
                        case TextBoxHelper.Password:
                            password = textBox.Text;
                            break;
                        case TextBoxHelper.ConfirmPassword:
                            confirmPassword = textBox.Text;
                            break;
                    }
            }

            if (password.GetHashedString() == confirmPassword.GetHashedString())
            {
                customer.Password = password.GetHashedString();
                registrationView.Register(customer);
            }
            else
                MessageBox.Show("Passwords do not match!");
        }
    }
}
