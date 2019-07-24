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
        Carro Get(Guid key);
    }
}
