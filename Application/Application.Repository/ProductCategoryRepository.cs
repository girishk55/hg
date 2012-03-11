using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ProductCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<ProductCategory> GetAllProductCategories(int page, int pageSize)
        {
            var results = from o in DataContext.ProductCategories
                          orderby o.ProductCategoryID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<ProductCategory> GetPagedResultForQuery(IQueryable<ProductCategory> query, int page, int pageSize)
        {
            var result = new PagedResult<ProductCategory>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;

        }

    }
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        PagedResult<ProductCategory> GetAllProductCategories(int page, int pageSize);
    }

}
