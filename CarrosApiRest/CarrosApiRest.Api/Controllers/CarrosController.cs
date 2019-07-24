using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Service;
using CarrosApiRest.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarrosApiRest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly ILogger<CarrosController> _logger;

        public CarrosController(ICarroService carroService, ILogger<CarrosController> logger)
        {
            _carroService = carroService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Carro>> Get()
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_carroService.List());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Carro> Get([FromRoute] Guid key)
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_carroService.Get(key));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("marca/{marca}")]
        public ActionResult<Carro> Get([FromRoute] string marca)
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_carroService.ListForMarca(marca));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Carro carro)
        {
            try
            {
                _logger.LogInformation("Received post request");

                if (ModelState.IsValid)
                {
                    _carroService.Add(carro);

                    return Ok("success");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }

    }
}
