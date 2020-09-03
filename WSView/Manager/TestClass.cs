using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.Resource;

namespace WebShop.Manager
{
    public class TestClass
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public void TestMethod()
        {
            customerDA.Insert(new Customer { ID = Guid.NewGuid(), FirstName = "TestingWPF", LastName = "TestingWPF", CustomerType = CustomerType.Old });
        }
    }
}
