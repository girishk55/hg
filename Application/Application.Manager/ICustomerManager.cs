using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Model;
using Application.Model.DTO;

namespace Application.Manager
{
    public interface ICustomerManager
    {
        Customer GeCustomerByCustomerID(int id);
        CustomerDTO ValidateCustomer(int id, string password);
        CustomerDTO SaveOrUpdateCustomer(CustomerDTO customer);
    }
}
