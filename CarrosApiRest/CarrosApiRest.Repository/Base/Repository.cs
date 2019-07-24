using CarrosApiRest.Domain.Entity.Interfaces;
using CarrosApiRest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarrosApiRest.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private List<TEntity> _data;

        private static object _syncObj = new object();

        public Repository()
        {
            if (_data == null)
            {
                lock (_syncObj)
                {
                    if (_data == null)
                    {
                        _data = new List<TEntity>();
                    }
                }
            }
        }

        public TEntity Get(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public TEntity Get(Guid key)
        {
            return _data.Find(x => x.Key == key);
        }

        public List<TEntity> Get(int skip, int take)
        {
            return _data.Skip(skip).Take(take).ToList();
        }

        public List<TEntity> Get()
        {
            return _data;
        }

        public void Create(TEntity entity)
        {
            _data.Add(entity);
        }

        public void Update(TEntity entity)
        {
            TEntity oldEntity = Get(entity.Key);
            Delete(oldEntity);
            Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _data.Remove(entity);
        }
    }
}
