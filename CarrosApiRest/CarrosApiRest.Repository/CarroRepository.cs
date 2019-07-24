using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Repository.Base;
using CarrosApiRest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrosApiRest.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
    }
}
