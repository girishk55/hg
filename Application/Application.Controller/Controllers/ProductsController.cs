using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Application.Controller.Log;
using Application.Manager;
using Application.Controller.Filters;
using Application.Model;

namespace Application.Controller.Controllers
{
    public class ProductsController : ApiController
    {
        ILogService loggerService;
        IProductManager _productManager;

        public ProductsController(ILogService loggerService, IProductManager productManager)
        {
            this.loggerService = loggerService;
            this._productManager = productManager;
        }

        /// <summary>
        /// To fetch all Product
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public IQueryable<Product> GetProducts()
        {
            loggerService.Logger().Info("Calling with null parameter");
            return _productManager.GetProducts().AsQueryable<Product>();
        }

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public IQueryable<Product> GetProductByProductCategoryID(int id)
        {
            loggerService.Logger().Info("Calling with null parameter as : id : " + id );
            return _productManager.GetProductByProductCategoryID(id).AsQueryable<Product>();
        }
    }
}
