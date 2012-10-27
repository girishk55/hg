using Application.DAL.Contracts;
using Application.DAL.Implementations;
using Application.Model;

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

    }
    public interface ISalesOrderHeaderRepository : IRepository<SalesOrderHeader>
    {
    }
}
