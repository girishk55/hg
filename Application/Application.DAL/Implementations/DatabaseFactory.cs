using Application.DAL.Contracts;
using Application.Model;

namespace Application.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AdventureWorksEntities dataContext;
        public AdventureWorksEntities Get()
        {
            return dataContext ?? (dataContext = new AdventureWorksEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
