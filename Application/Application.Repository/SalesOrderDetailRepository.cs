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

    }
    public interface ISalesOrderDetailRepository : IRepository<SalesOrderDetail>
    {
    }

}