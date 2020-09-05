using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSView.Model;

namespace WSView.Manager
{
    public interface ICustomerManager
    {

        ValidationError[] CreateCustomer(Customer customer);

    }
}
