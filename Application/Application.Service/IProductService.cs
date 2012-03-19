using System.Collections.Generic;
using Application.Model;

namespace Application.Service
{
    public interface IProductService
    {
        List<ProductCategory> GetProductCategories();
        List<Product> GetProductByProductCategoryID(int id);
    }
}
