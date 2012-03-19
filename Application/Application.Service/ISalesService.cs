using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Model.DTO;

namespace Application.Service
{
    public interface ISalesService
    {
        InvoiceDTO GetInvoiceBySaleOrderID(int id);
        int SaveSalesOrderHeader(SalesOrderDTO salesOrder);
    }
}
