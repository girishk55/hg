
namespace Application.DAL
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
