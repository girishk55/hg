using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Application.Controller.Log;
using Application.Manager;
using Application.Controller.Filters;
using Application.Model;
using Application.Model.DTO;

namespace Application.Controller.Controllers
{
    public class CustomersController : ApiController
    {
        ILogService loggerService;
        ICustomerManager _customerManager;

        public CustomersController(ILogService loggerService, ICustomerManager customerManager)
        {
            this.loggerService = loggerService;
            this._customerManager = customerManager;
        }

        /// <summary>
        /// To fetch Customer by Customer ID
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public Customer GeCustomerByCustomerID(int id)
        {
            loggerService.Logger().Info("Calling with null parameter as : id : " + id);
            return _customerManager.GeCustomerByCustomerID(id);
        }

        /// <summary>
        /// To validate Customer
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public CustomerDTO GetValidateCustomer(int id, string password)
        {
            loggerService.Logger().Info("Calling with parameter as : id and password: " + id + " and " + password);
            return _customerManager.ValidateCustomer(id, password);
        }

        /// <summary>
        /// To Save Customer
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public CustomerDTO PostCustomer(CustomerDTO customer)
        {
            loggerService.Logger().Info("Calling with parameter as : customer: " + customer );
            return _customerManager.SaveOrUpdateCustomer(customer);
        }
    }
}
