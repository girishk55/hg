using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Application.Manager;
using Application.Controller.Log;
using Application.Controller.Filters;
using Application.Model;
using System.Json;

namespace Application.Controller.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        ILogService loggerService;
        IProductManager _productManager;

        public ProductCategoriesController(ILogService loggerService, IProductManager productManager)
        {
            this.loggerService = loggerService;
            this._productManager = productManager;
        }

        /// <summary>
        /// To fetch all Product Categories
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public IQueryable<ProductCategory> GetProductCategories()
        {
            loggerService.Logger().Info("Calling with null parameter");
            return _productManager.GetProductCategories().AsQueryable<ProductCategory>();
        }

        /// <summary>
        /// To fetch Product Category by ID
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        public ProductCategory GetProductCategoryByID(int id)
        {
            loggerService.Logger().Info("Calling with null parameter");
            return _productManager.GetProductCategoryByID(id);
        }
    }
}
