using System.Collections.Generic;
using System.Linq;
using Application.DAL;
using Application.Repository;
using Application.Model;

namespace Application.Service
{
    public class ProductService : IProductService
    {
        IUnitOfWork unitOfWork;
        IProductCategoryRepository _productCategoriesRepository;
        IProductRepository _productsRepository;

        public ProductService(
            IUnitOfWork unitOfWork,
            IProductRepository productsRepository,
            IProductCategoryRepository productCategoriesRepository)
        {
            this.unitOfWork = unitOfWork;
            this._productCategoriesRepository = productCategoriesRepository;
            this._productsRepository = productsRepository;
        }

        #region ProductCategory

        /// <summary>
        /// To fetch Product Category by ID
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductByProductCategoryID(int id)
        {
            List<Product> products;
            if (id > 4)
            {
                products = _productsRepository.GetMany(x => x.ProductCategoryID == id).ToList();
            }
            else
                products = _productsRepository.GetMany(x => x.ProductCategory.ParentProductCategoryID == id).ToList();
            return products;
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
            productCategories = _productCategoriesRepository.GetAll().ToList();
            return productCategories;
        }

        #endregion ProductCategory

    }
}
