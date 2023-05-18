
namespace ContribuyentesDGII.Tests
{
    public class ContribuyentesControllerTests
    {
        private readonly ContribuyentesController _controller;
        private readonly Mock<IContribuyenteService> _contribuyenteServiceMock;
        private readonly Mock<ILogger<ContribuyentesController>> _loggerMock;
        public ContribuyentesControllerTests()
        {
            _contribuyenteServiceMock = new Mock<IContribuyenteService>();
            _loggerMock = new Mock<ILogger<ContribuyentesController>>();
            _controller = new ContribuyentesController(_contribuyenteServiceMock.Object, _loggerMock.Object);
        }
        [Fact]
        public async void GetAll_ReturnsOkResultWithContribuyentes()
        {
            // Arrange
            var expectedContribuyentes = GetContribuyentes();
            _contribuyenteServiceMock.Setup(s => s.GetContribuyentes()).ReturnsAsync(expectedContribuyentes);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContribuyentes = Assert.IsAssignableFrom<IEnumerable<ContribuyenteDTO>>(okResult.Value);
            Assert.Equal(2, actualContribuyentes.Count());
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

        private static List<ContribuyenteDTO> GetContribuyentes()
        {
            List<ContribuyenteDTO> contribuyentes = new();
            contribuyentes.Add(new ContribuyenteDTO
            {
                RncCedula = "98754321012",
                Nombre = "JUAN PEREZ",
                Tipo = "PERSONA FISICA",
                Estatus = "activo"
            });
            contribuyentes.Add(new ContribuyenteDTO
            {
                RncCedula = "23456789",
                Nombre = "FARMACIA TU SALUD",
                Tipo = "PERSONA JURIDICA",
                Estatus = "inactivo"
            });
            return contribuyentes;
        }

        // Write similar unit tests for other methods (Create, Update, Delete)

        // Remember to also write unit tests to cover error/exception scenarios and edge cases

        // You can use Moq (a mocking framework) to mock the dependencies (IContribuyenteService) and set up expected behavior in the Arrange phase of the tests
    }
}
