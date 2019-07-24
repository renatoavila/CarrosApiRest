using CarrosApiRest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrosApiRest.Business.Interface
{
    public interface ICarroBusiness
    {
        void Add(Carro carro);
        List<Carro> List();
        List<Carro> ListForMarca(string marca);
        Carro Get(Guid key);


    }
}
