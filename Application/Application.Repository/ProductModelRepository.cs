using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class ProductModelRepository : Repository<ProductModel>, IProductModelRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ProductModelRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<ProductModel> GetAllProductModels(int page, int pageSize)
        {
            var results = from o in DataContext.ProductModels
                          orderby o.ProductModelID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<ProductModel> GetPagedResultForQuery(IQueryable<ProductModel> query, int page, int pageSize)
        {
            var result = new PagedResult<ProductModel>();
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
    public interface IProductModelRepository : IRepository<ProductModel>
    {
        PagedResult<ProductModel> GetAllProductModels(int page, int pageSize);
    }

}
