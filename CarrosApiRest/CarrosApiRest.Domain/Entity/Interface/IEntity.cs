using System;

namespace CarrosApiRest.Domain.Entity.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid Key { get; set; }
    }
}
