using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class ProductDescriptionRepository : Repository<ProductDescription>, IProductDescriptionRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ProductDescriptionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<ProductDescription> GetAllProductDescriptions(int page, int pageSize)
        {
            var results = from o in DataContext.ProductDescriptions
                          orderby o.ProductDescriptionID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<ProductDescription> GetPagedResultForQuery(IQueryable<ProductDescription> query, int page, int pageSize)
        {
            var result = new PagedResult<ProductDescription>();
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
    public interface IProductDescriptionRepository : IRepository<ProductDescription>
    {
        PagedResult<ProductDescription> GetAllProductDescriptions(int page, int pageSize);
    }

}
