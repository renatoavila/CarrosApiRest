using CarrosApiRest.Business;
using CarrosApiRest.Business.Interface;
using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrosApiRest.Service
{
    public class CarroService : ICarroService
    {
       private readonly  ICarroBusiness _carroBusiness; 
        public CarroService(ICarroBusiness carroBusiness )
        {
            _carroBusiness = carroBusiness;
        }
        public void Add(Carro carro)
        {
            _carroBusiness.Add(carro);
        }

        public Carro Get(Guid key)
        {
           return  _carroBusiness.Get(key);
        }

        public List<Carro> List()
        {
            return _carroBusiness.List();
        }
    }
}
