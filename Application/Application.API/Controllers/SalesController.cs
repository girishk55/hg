using System.Web.Http;
using Application.Common.Log;
using Application.Common.Filters;
using Application.Service;
using Application.Model.DTO;

namespace Application.API.Controllers
{
    public class SalesController : ApiController
    {
        ILogService loggerService;
        ISalesService _saleService;

        public SalesController(ILogService loggerService, ISalesService saleService)
        {
            this.loggerService = loggerService;
            this._saleService = saleService;
        }

        /// <summary>
        /// To fetch Sales Header by SalesHeader ID
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public InvoiceDTO GetInvoiceBySaleOrderID(int id)
        {
            loggerService.Logger().Info("Calling with parameter as : id : " + id);
            return _saleService.GetInvoiceBySaleOrderID(id);
        }

        /// <summary>
        /// To Save Sales details
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public int PostSalesOrderHeader(SalesOrderDTO salesOrder)
        {
            loggerService.Logger().Info("Calling with parameter as : salesOrder: " + salesOrder);
            return _saleService.SaveSalesOrderHeader(salesOrder);
        }

    }
}
