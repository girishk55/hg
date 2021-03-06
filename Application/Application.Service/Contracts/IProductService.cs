﻿using Application.Model;
using System.Collections.Generic;

namespace Application.Service.Contracts
{
    public interface IProductService
    {
        List<ProductCategory> GetProductCategories();
        List<Product> GetProductByProductCategoryID(int id);
    }
}
