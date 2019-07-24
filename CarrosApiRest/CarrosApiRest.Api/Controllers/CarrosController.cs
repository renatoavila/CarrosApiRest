using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Service;
using CarrosApiRest.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarrosApiRest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;
        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Carro>> Get()
        {
            return _carroService.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Carro> Get(Guid key)
        {
            return _carroService.Get(key); ;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Carro carro)
        {
            _carroService.Add(carro);
        }

    }
}
