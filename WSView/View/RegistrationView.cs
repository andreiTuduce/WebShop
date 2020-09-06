using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WSView.Manager;
using WSView.Model;
using WSView.View.Helper;

namespace WSView.View
{
    public class RegistrationView
    {
        private readonly CustomerManager customerManager = new CustomerManager();
        private readonly string[] registrationControls = new[] { TextBoxHelper.FirstName, TextBoxHelper.LastName, TextBoxHelper.Username, TextBoxHelper.Password, TextBoxHelper.ConfirmPassword };

        public void Register(Customer customer)
        {
            Model.ValidationError[] errors = customerManager.CreateCustomer(customer);

            if (errors.Length > 0)
                MessageBox.Show(errors[0].ValidationMessage);
            else
                MessageBox.Show("Registration successfully!");
        }

        public (TextBox[], PasswordBox[]) ChangeViewToRegistration()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            List<PasswordBox> passwordBoxes = new List<PasswordBox>();

            int index = 0;
            foreach (string registrationControl in registrationControls)
            {
                if (index <= 2)
                    textBoxes.Add(TextBoxHelper.GetTextBox(registrationControl, index));
                else
                    passwordBoxes.Add(TextBoxHelper.GetPasswordBox(registrationControl, index));
                index++;
            }

            return (textBoxes.ToArray(), passwordBoxes.ToArray());
        }
    }
}
