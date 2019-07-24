using CarrosApiRest.Business.Interface;
using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrosApiRest.Business
{
    public class CarroBusiness : ICarroBusiness
    {
        private readonly ICarroRepository _carroRepository;
        public CarroBusiness(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public void Add(Carro carro)
        {
            _carroRepository.Create(carro);
        }

        public Carro Get(Guid key)
        {
            return _carroRepository.Get(key);
        }
         
        public List<Carro> List()
        {
            return _carroRepository.Get();
        }

        public List<Carro> ListForMarca(string marca)
        {
            return _carroRepository.GetListForMarca(marca);
        }
    }
}
