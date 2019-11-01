using System.Collections.Generic;
using Core.Entities;

namespace Core.Abstractions
{
    public interface IRepository<TDomain> where TDomain : IAggregateRoot
    {
        void Add(TDomain entity);
        void Update(TDomain entity);
        void Remove(TDomain entity);
        IEnumerable<TDomain> FindAll();
        TDomain FindOne(string id);
    }
}