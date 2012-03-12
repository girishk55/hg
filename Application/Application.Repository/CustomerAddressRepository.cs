using System;
using Application.DAL;
using Application.Model;
using System.Linq;

namespace Application.Repository
{
    public class CustomerAddressRepository : Repository<CustomerAddress>, ICustomerAddressRepository
    {
        private AdventureWorksEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public CustomerAddressRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected AdventureWorksEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public PagedResult<CustomerAddress> GetAllCustomerAddresses(int page, int pageSize)
        {
            var results = from o in DataContext.CustomerAddresses
                          orderby o.CustomerID
                          select o;

            var result = GetPagedResultForQuery(results, page, pageSize);
            return result;
        }

        private PagedResult<CustomerAddress> GetPagedResultForQuery(IQueryable<CustomerAddress> query, int page, int pageSize)
        {
            var result = new PagedResult<CustomerAddress>();
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
    public interface ICustomerAddressRepository : IRepository<CustomerAddress>
    {
        PagedResult<CustomerAddress> GetAllCustomerAddresses(int page, int pageSize);
    }

}
