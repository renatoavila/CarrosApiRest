using CarrosApiRest.Api.Controllers;
using CarrosApiRest.Domain.Entity;
using CarrosApiRest.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace CarrosApiRest.Api.Test
{
    public class CarrosController_Test
    {
        [Fact]
        public void GetOk()
        {
            var carroServiceMock = new Mock<ICarroService>();
            var loggerMock = new Mock<ILogger<CarrosController>>();

            carroServiceMock.Setup(
                c => c.Add(It.IsAny<Carro>()));

            var carroExpectancy = new List<Carro>
            {
                new Carro() {  Marca = "Fiat", Modelo = "Palio", Ano = "2019" },
                new Carro() {  Marca = "Chevrolet", Modelo = "Onix", Ano = "2019" },
            };

            carroServiceMock.Setup(a => a.List()).Returns(carroExpectancy);

            var controller = new CarrosController(carroServiceMock.Object, loggerMock.Object);

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);

            var httpObjResult = result.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));

            List<Carro> valueRetorno = (List<Carro>)value;
            for (var index = 0; index < valueRetorno.Count(); index++)
            {
                Assert.Equal(carroExpectancy[index].Id, valueRetorno[index].Id);
                Assert.Equal(carroExpectancy[index].Key, valueRetorno[index].Key);
                Assert.Equal(carroExpectancy[index].Marca, valueRetorno[index].Marca);
                Assert.Equal(carroExpectancy[index].Modelo, valueRetorno[index].Modelo);
                Assert.Equal(carroExpectancy[index].Ano, valueRetorno[index].Ano);
            }
        }

        [Fact]
        public void GetInternalServerError()
        {

        }

        [Fact]
        public void PostOk()
        {
            var carroServiceMock = new Mock<ICarroService>();
            var loggerMock = new Mock<ILogger<CarrosController>>();

            carroServiceMock.Setup(
                c => c.Add(It.IsAny<Carro>()));

            var controller = new CarrosController(carroServiceMock.Object, loggerMock.Object);

            var result = controller.Post(new Carro() { Marca = "Fiat", Modelo = "Palio", Ano = "2019" });

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);

            var httpObjResult = result.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            Assert.Same("success", value);
        }

        [Fact]
        public void PostPosBadRequestt()
        {

        }
    }
}
