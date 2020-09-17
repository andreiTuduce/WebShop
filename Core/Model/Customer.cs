using System;

namespace Core.Model
{
    public class Customer
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerType CustomerType { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    public enum CustomerType
    {
        None = 0,
        New = 1,
        Old = 2
    }
}
