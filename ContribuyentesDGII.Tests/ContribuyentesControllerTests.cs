
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
            var expectedContribuyentes = new List<ContribuyenteDTO> { };
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

       
        // Write similar unit tests for other methods (Create, Update, Delete)

        // Remember to also write unit tests to cover error/exception scenarios and edge cases

        // You can use Moq (a mocking framework) to mock the dependencies (IContribuyenteService) and set up expected behavior in the Arrange phase of the tests
    }
}
