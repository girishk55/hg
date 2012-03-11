using System;

namespace Application.DAL
{
    public interface IDatabaseFactory : IDisposable
    {
        AdventureWorksEntities Get();
    }
}
