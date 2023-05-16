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
    }
}
