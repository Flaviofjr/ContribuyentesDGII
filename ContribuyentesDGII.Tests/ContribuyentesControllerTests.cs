using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContribuyentesDGII.Api.Controllers;
using ContribuyentesDGII.Api.Services;
using ContribuyentesDGII.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using ContribuyentesDGII.Core.DTOs;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContribuyentesDGII.Core.Models;

namespace ContribuyentesDGII.Tests
{
    public class ContribuyentesControllerTests
    {
        private readonly ContribuyentesController _controller;
        private readonly Mock<IContribuyenteService> _contribuyenteServiceMock;
        public ContribuyentesControllerTests()
        {
            _contribuyenteServiceMock = new Mock<IContribuyenteService>();
            _controller = new ContribuyentesController(_contribuyenteServiceMock.Object);
        }
        [Fact]
        public async void GetAll_ReturnsOkResultWithContribuyentes()
        {
            // Arrange
            var expectedContribuyentes = new List<ContribuyenteDTO> { /* Add expected contribuyentes here */ };
            _contribuyenteServiceMock.Setup(s => s.GetContribuyentes()).ReturnsAsync(expectedContribuyentes);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContribuyentes = Assert.IsAssignableFrom<IEnumerable<ContribuyenteDTO>>(okResult.Value);
            Assert.Equal(expectedContribuyentes, actualContribuyentes);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkResultWithContribuyente()
        {
            // Arrange
            string id = "123456789";
            var expectedContribuyente = new Contribuyente 
            {
                RncCedula = id,
                Nombre = "FARMACIA TU SALUD",
                IdTipoPersona = 2,
                IdEstatus = 2
            };
            _contribuyenteServiceMock.Setup(s => s.GetContribuyente(id)).ReturnsAsync(expectedContribuyente);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContribuyente = Assert.IsAssignableFrom<Contribuyente>(okResult.Value);
            Assert.Equal(expectedContribuyente, actualContribuyente);
        }

        [Fact]
        public async Task GetById_ItbisTotalFromContribuyente()
        {
            //Arrange
            string rncCedula = "98754321012";
            var expectedContribuyente = new Contribuyente
            {
                RncCedula = rncCedula,
                Nombre = "JUAN PEREZ",
                IdTipoPersona = 1,
                IdEstatus = 1,
                Comprobantes = GetComprobantesFromContribuyente(rncCedula)
            };
            decimal expectedResult = Math.Round((decimal)216.00,2);
            _contribuyenteServiceMock.Setup(s => s.GetContribuyente(rncCedula)).ReturnsAsync(expectedContribuyente); ;
            
            // Act
            var result = await _controller.GetById(rncCedula);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContribuyente = Assert.IsAssignableFrom<Contribuyente>(okResult.Value);
            Assert.Equal(expectedResult, Math.Round(actualContribuyente.Comprobantes.Sum(i => i.Itbis18),2));
        }
        private List<ComprobanteFiscal> GetComprobantesFromContribuyente(string rncCedula)
        {
            List<ComprobanteFiscal> comprobantes = new();
            comprobantes.Add(new ComprobanteFiscal
            {
                NCF = "E310000000001",
                Monto = Math.Round((decimal)200.00, 2),
                Itbis18 = Math.Round((decimal)36.00, 2),
                RncCedula = "98754321012"
            });
            comprobantes.Add(new ComprobanteFiscal
            {
                NCF = "E310000000002",
                Monto = Math.Round((decimal)1000.00, 2),
                Itbis18 = Math.Round((decimal)180.00, 2),
                RncCedula = "98754321012"
            });
            return comprobantes.Where(r => r.RncCedula == rncCedula).ToList();
        }
        // Write similar unit tests for other methods (Create, Update, Delete)

        // Remember to also write unit tests to cover error/exception scenarios and edge cases

        // You can use Moq (a mocking framework) to mock the dependencies (IContribuyenteService) and set up expected behavior in the Arrange phase of the tests
    }
}
