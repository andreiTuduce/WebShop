using System.Windows.Controls;
using WSView.Manager;
using WSView.Model;
using WSView.View.Helper;

namespace WSView.View
{
    public class LoginView
    {

        private readonly CustomerManager customerManager = new CustomerManager();
        private readonly string[] loginControls = new[] { TextBoxHelper.Username, TextBoxHelper.Password };
        
        public Customer LoginCustomer(string username)
        {
            return customerManager.GetCustomer(username);
        }

        public (TextBox[] textBoxes, PasswordBox[] passwordBoxes) GetControls()
        {
            return (new[] { TextBoxHelper.GetTextBox(loginControls[0], 0) }, new[] { TextBoxHelper.GetPasswordBox(loginControls[1], 1) });
        }
    }
}
