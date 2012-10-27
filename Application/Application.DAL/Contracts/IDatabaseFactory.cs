using Application.Model;
using System;

namespace Application.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        AdventureWorksEntities Get();
    }
}
