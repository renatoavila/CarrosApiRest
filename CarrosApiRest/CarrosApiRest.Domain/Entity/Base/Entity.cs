using CarrosApiRest.Domain.Entity.Interfaces;
using System;
 
namespace CarrosApiRest.Domain.Entity.Base
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Key = Guid.NewGuid();
        }
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}
