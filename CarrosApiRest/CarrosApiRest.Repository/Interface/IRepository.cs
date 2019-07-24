using System;
using System.Collections.Generic;

namespace CarrosApiRest.Repository.Interface
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        TEntity Get(Guid key);
        List<TEntity> Get();
        List<TEntity> Get(int skip, int take);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
