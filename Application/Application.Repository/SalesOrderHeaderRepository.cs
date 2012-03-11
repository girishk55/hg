using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class SalesOrderHeaderRepository : Repository<SalesOrderHeader>, ISalesOrderHeaderRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public SalesOrderHeaderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<SalesOrderHeader> GetAllSalesOrderHeaders(int page, int pageSize)
        {
            var results = from o in DataContext.SalesOrderHeaders
                          orderby o.SalesOrderID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<SalesOrderHeader> GetPagedResultForQuery(IQueryable<SalesOrderHeader> query, int page, int pageSize)
        {
            var result = new PagedResult<SalesOrderHeader>();
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
    public interface ISalesOrderHeaderRepository : IRepository<SalesOrderHeader>
    {
        PagedResult<SalesOrderHeader> GetAllSalesOrderHeaders(int page, int pageSize);
    }

}
