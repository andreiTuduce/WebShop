using System.Windows;
using System.Windows.Controls;

namespace WSView.View.Helper
{
    public static class TextBoxHelper
    {

        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string Username = "Username";
        public const string Password = "Password";
        public const string ConfirmPassword = "ConfirmPassword";

        private static readonly int InitialViewPosition = 120;
        private static readonly int MarginTop = 28;
        private static readonly int MarginLeft = 377;
        private static readonly int Height = 23;
        private static readonly int Width = 120;

        public static TextBox GetTextBox(string textBoxName, int buttonIndex)
        {
            return new TextBox
            {
                Name = textBoxName,
                Height = Height,
                Width = Width,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(MarginLeft, InitialViewPosition + MarginTop * buttonIndex, 0, 0)
            };
        }

        public static PasswordBox GetPasswordBox(string passwordBoxName, int buttonIndex)
        {
            return new PasswordBox
            {
                Name = passwordBoxName,
                Height = Height,
                Width = Width,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(MarginLeft, InitialViewPosition + MarginTop * buttonIndex, 0, 0)
            };
        }
    }
}
