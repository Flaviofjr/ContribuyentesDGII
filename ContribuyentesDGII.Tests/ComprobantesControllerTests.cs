
namespace ContribuyentesDGII.Tests
{
    public class ComprobantesControllerTests
    {
        private readonly ComprobantesFiscalesController _controller;
        private readonly Mock<IComprobanteFiscalService> _comprobanteServiceMock;
        private readonly Mock<IContribuyenteService> _contribuyenteServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<ComprobantesFiscalesController>> _loggerMock;
        private readonly MapperConfiguration mapperConfig;
        private readonly IMapper mapper;
        public ComprobantesControllerTests()
        {
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>(); // Add your AutoMapper mapping profile
            });
            // Use the mapperConfig to create a new IMapper instance
            mapper = mapperConfig.CreateMapper();
            _comprobanteServiceMock = new Mock<IComprobanteFiscalService>();
            _contribuyenteServiceMock = new Mock<IContribuyenteService>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<ComprobantesFiscalesController>>();

            _controller = new ComprobantesFiscalesController(_comprobanteServiceMock.Object,
                _contribuyenteServiceMock.Object,
                _loggerMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async void GetAll_ReturnsOkResultWithComprobantes()
        {
            // Arrange
            var expectedComprobantes = mapper.Map<List<ComprobanteDTO>, List<ComprobanteFiscal>>(GetComprobantes());
            _comprobanteServiceMock.Setup(s => s.GetComprobantes()).ReturnsAsync(expectedComprobantes);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualComprobantes = Assert.IsAssignableFrom<IEnumerable<ComprobanteFiscal>>(okResult.Value);
            Assert.Equal(expectedComprobantes, actualComprobantes);
        }

        [Fact]
        public async Task GetById_ItbisTotalFromContribuyente()
        {
            //Arrange
            string rncCedula = "98754321012";
            var expectedComprobantes = mapper.Map<List<ComprobanteDTO>, List<ComprobanteFiscal>>(GetComprobantes());
            decimal expectedResult = Math.Round((decimal)216.00, 2);
            _comprobanteServiceMock.Setup(s => s.GetComprobantes()).ReturnsAsync(expectedComprobantes);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualComprobantes = Assert.IsAssignableFrom<IEnumerable<ComprobanteFiscal>>(okResult.Value)
                .Where(r => r.RncCedula == rncCedula).ToList();
            Assert.Equal(expectedResult, Math.Round(actualComprobantes.Sum(c => c.Itbis18), 2));
        }

        private static List<ComprobanteDTO> GetComprobantes()
        {
            List<ComprobanteDTO> comprobantes = new();
            comprobantes.Add(new ComprobanteDTO
            {
                NCF = "E310000000001",
                Monto = Math.Round((decimal)200.00, 2),
                //Itbis18 = Math.Round((decimal)36.00, 2),
                RncCedula = "98754321012"
            });
            comprobantes.Add(new ComprobanteDTO
            {
                NCF = "E310000000002",
                Monto = Math.Round((decimal)1000.00, 2),
                //Itbis18 = Math.Round((decimal)180.00, 2),
                RncCedula = "98754321012"
            });
            return comprobantes;
        }
    }
}
