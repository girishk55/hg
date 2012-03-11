using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class ProductModelProductDescriptionRepository : Repository<ProductModelProductDescription>, IProductModelProductDescriptionRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ProductModelProductDescriptionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<ProductModelProductDescription> GetAllProductModelProductDescriptions(int page, int pageSize)
        {
            var results = from o in DataContext.ProductModelProductDescriptions
                          orderby o.ProductModelID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<ProductModelProductDescription> GetPagedResultForQuery(IQueryable<ProductModelProductDescription> query, int page, int pageSize)
        {
            var result = new PagedResult<ProductModelProductDescription>();
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
    public interface IProductModelProductDescriptionRepository : IRepository<ProductModelProductDescription>
    {
        PagedResult<ProductModelProductDescription> GetAllProductModelProductDescriptions(int page, int pageSize);
    }

}
