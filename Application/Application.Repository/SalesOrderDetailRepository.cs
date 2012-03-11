using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class SalesOrderDetailRepository : Repository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public SalesOrderDetailRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<SalesOrderDetail> GetAllSalesOrderDetails(int page, int pageSize)
        {
            var results = from o in DataContext.SalesOrderDetails
                          orderby o.SalesOrderDetailID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<SalesOrderDetail> GetPagedResultForQuery(IQueryable<SalesOrderDetail> query, int page, int pageSize)
        {
            var result = new PagedResult<SalesOrderDetail>();
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
    public interface ISalesOrderDetailRepository : IRepository<SalesOrderDetail>
    {
        PagedResult<SalesOrderDetail> GetAllSalesOrderDetails(int page, int pageSize);
    }

}
