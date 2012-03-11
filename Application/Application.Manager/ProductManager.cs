using System.Collections.Generic;
using Application.Service;
using Application.Model;

namespace Application.Manager
{
    public class ProductManager : IProductManager
    {
        IProductService _productService;

        public ProductManager(
            IProductService productService)
        {
            this._productService = productService;
        }

        #region Product

        /// <summary>
        /// To fetch all Product
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> products;
            products = _productService.GetProducts();
            return products;
        }

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductByProductCategoryID(int id)
        {
            return _productService.GetProductByProductCategoryID(id);
        }
        #endregion ProductCategory


        #region ProductCategory

        /// <summary>
        /// To fetch all ProductCategories
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> productCategories;
            productCategories = _productService.GetProductCategories();
            return productCategories;
        }

        /// <summary>
        /// To fetch Product Category by ID
        /// </summary>
        /// <returns></returns>
        public ProductCategory GetProductCategoryByID(int id)
        {
            return _productService.GetProductCategoryByID(id);
        }
        #endregion ProductCategory

    }
}
