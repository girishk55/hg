using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Service;
using Application.Model;
using Application.Model.DTO;

namespace Application.Manager
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerService _customerService;

        public CustomerManager(
           ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public Customer GeCustomerByCustomerID(int id)
        {
            return _customerService.GeCustomerByCustomerID(id);;
        }

        public CustomerDTO ValidateCustomer(int id, string password)
        {
            return _customerService.ValidateCustomer(id, password);
        }

        public int SaveOrUpdateCustomer(CustomerDTO customer)
        {
            return _customerService.SaveOrUpdateCustomer(customer);
        }
    }
}
