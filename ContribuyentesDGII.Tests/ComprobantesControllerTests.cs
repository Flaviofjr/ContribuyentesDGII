
namespace ContribuyentesDGII.Tests
{
    public class ComprobantesControllerTests
    {
        private readonly ComprobantesFiscalesController _controller;
        private readonly Mock<IComprobanteFiscalService> _comprobanteServiceMock;
        private readonly Mock<ILogger<ComprobantesFiscalesController>> _loggerMock;
        public ComprobantesControllerTests()
        {
            _comprobanteServiceMock = new Mock<IComprobanteFiscalService>();
            _loggerMock = new Mock<ILogger<ComprobantesFiscalesController>>();
            _controller = new ComprobantesFiscalesController(_comprobanteServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetById_ItbisTotalFromContribuyente()
        {
            //Arrange
            string rncCedula = "98754321012";
            var expectedComprobantes = GetComprobantes();
            decimal expectedResult = Math.Round((decimal)216.00, 2);
            _comprobanteServiceMock.Setup(s => s.GetComprobantes()).ReturnsAsync(expectedComprobantes);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualComprbantes = Assert.IsAssignableFrom<IEnumerable<ComprobanteFiscal>>(okResult.Value)
                .Where(r => r.RncCedula == rncCedula).ToList();
            Assert.Equal(expectedResult, Math.Round(actualComprbantes.Sum(c => c.Itbis18), 2));
        }

        private List<ComprobanteFiscal> GetComprobantes()
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
            return comprobantes;
        }
    }
}
