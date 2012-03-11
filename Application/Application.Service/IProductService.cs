using System.Collections.Generic;
using Application.Model;

namespace Application.Service
{
    public interface IProductService
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryByID(int id);
        List<Product> GetProducts();
        List<Product> GetProductByProductCategoryID(int id);
    }
}
