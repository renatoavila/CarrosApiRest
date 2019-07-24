using CarrosApiRest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrosApiRest.Service.Interface
{
    public interface ICarroService
    {
        void Add(Carro carro);
        List<Carro> List();
        Carro Get(Guid key);
    }
}
