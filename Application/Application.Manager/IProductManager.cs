using System.Collections.Generic;
using Application.Model;

namespace Application.Manager
{
    public interface IProductManager
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryByID(int id);
        List<Product> GetProducts();
        List<Product> GetProductByProductCategoryID(int id);
    }
}
