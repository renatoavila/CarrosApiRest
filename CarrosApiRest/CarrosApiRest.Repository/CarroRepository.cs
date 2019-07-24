using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Repository.Base;
using CarrosApiRest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrosApiRest.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public List<Carro> GetListForMarca(string marca)
        {
            return Get().Where(x => x.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
