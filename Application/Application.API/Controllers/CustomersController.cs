using System.Web.Http;
using Application.Service;
using Application.Common.Log;
using Application.Common.Filters;
using Application.Model.DTO;

namespace Application.API.Controllers
{
    public class CustomersController : ApiController
    {
        ILogService loggerService;
        ICustomerService _customerService;

        public CustomersController(ILogService loggerService, ICustomerService customerService)
        {
            this.loggerService = loggerService;
            this._customerService = customerService;
        }

        /// <summary>
        /// To validate Customer
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public CustomerDTO ValidateCustomer(int id, string password)
        {
            loggerService.Logger().Info("Calling with parameter as : id and password: " + id + " and " + password);
            return _customerService.ValidateCustomer(id, password);
        }

        /// <summary>
        /// To Save Customer
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public int PostCustomer(CustomerDTO customer)
        {
            loggerService.Logger().Info("Calling with parameter as : customer: " + customer);
            return _customerService.SaveOrUpdateCustomer(customer);
        }

    }
}
