using CarrosApiRest.Domain.Entity;
using System.Collections.Generic;

namespace CarrosApiRest.Repository.Interface
{
    public interface ICarroRepository: IRepository<Carro>
    {
        List<Carro> GetListForMarca(string marca);
    }
}
