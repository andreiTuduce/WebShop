using System;
using System.Windows;
using System.Windows.Controls;
using WebShop.Infrastructure;
using WSView.Model;
using WSView.View;
using WSView.View.Helper;

namespace WSView
{
    public partial class MainWindow : Window
    {
        private readonly RegistrationView registrationView = new RegistrationView();
        private readonly LoginView loginView = new LoginView();
        private Customer customerDetails;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddControl(object sender, RoutedEventArgs e)
        {

            (TextBox[] textBoxes, PasswordBox[] passwordBoxes) = registrationView.GetControls();

            foreach (TextBox textBox in textBoxes)
            {
                MainGrid.Children.Add(textBox);

            }

            foreach (PasswordBox passwordBox in passwordBoxes)
            {
                MainGrid.Children.Add(passwordBox);
            }
        }

        private void AddLoginControl(object sender, RoutedEventArgs e)
        {
            (TextBox[] textBoxes, PasswordBox[] passwordBoxes) = loginView.GetControls();

            foreach (TextBox textBox in textBoxes)
            {
                MainGrid.Children.Add(textBox);

            }

            foreach (PasswordBox passwordBox in passwordBoxes)
            {
                MainGrid.Children.Add(passwordBox);
            }
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = null;
            string password = null;

            foreach (UIElement element in MainGrid.Children)
            {
                if (element is TextBox textBox)
                {
                    switch (textBox.Name)
                    {
                        case TextBoxHelper.Username:
                            username = textBox.Text;
                            break;
                    }
                }

                if (element is PasswordBox passwordBox)
                {
                    switch (passwordBox.Name)
                    {
                        case TextBoxHelper.Password:
                            password = passwordBox.Password.GetHashedString();
                            break;
                    }
                }

            }

            if (!string.IsNullOrWhiteSpace(username))
            {
                customerDetails = loginView.LoginCustomer(username);

                if (customerDetails == null)
                {
                    MessageBox.Show("This user does not exist!");
                    return;
                }

                if (customerDetails.Password == password)
                {
                    //go to next window
                }
                else
                {
                    MessageBox.Show("Password or username incorrect!");
                }
            }


        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer { ID = Guid.NewGuid(), CustomerType = CustomerType.New };

            string password = string.Empty;
            string confirmPassword = string.Empty;

            foreach (UIElement element in MainGrid.Children)
            {
                if (element is TextBox textBox)

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
                    }

                if (element is PasswordBox passwordBox)
                {
                    switch (passwordBox.Name)
                    {
                        case TextBoxHelper.Password:
                            password = passwordBox.Password;
                            break;
                        case TextBoxHelper.ConfirmPassword:
                            confirmPassword = passwordBox.Password;
                            break;
                    }
                }
            }

            if (password == confirmPassword)
            {
                customer.Password = password.GetHashedString();
                registrationView.Register(customer);
            }
            else
                MessageBox.Show("Passwords do not match!");
        }


    }
}
