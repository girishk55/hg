using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Model;
using Application.Model.DTO;

namespace Application.Service
{
    public interface ICustomerService
    {
        CustomerDTO ValidateCustomer(int id, string password);
        int SaveOrUpdateCustomer(CustomerDTO customer);
    }
}
