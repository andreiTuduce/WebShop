using Core.Model;
using Core.Resource;
using System;

namespace Core.Manager
{
    public class CustomerManager
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public void CreateCustomer(/*Customer customer*/)
        {
            customerDA.Insert(new Customer
            {
                ID = Guid.NewGuid(),
                FirstName = "TestingWPF",
                LastName = "TestingWPF",
                CustomerType = CustomerType.Old,
                Password = "Test",
                Username = "username"
            });

            //customerDA.Insert(customer);

        }

    }
}
