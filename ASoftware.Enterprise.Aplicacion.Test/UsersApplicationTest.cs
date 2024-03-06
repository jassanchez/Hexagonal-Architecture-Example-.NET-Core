using ASoftware.Enterprise.Aplicacion.Interfaz;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ASoftware.Enterprise.Aplicacion.Test {
    [TestClass]
    public class UsersApplicationTest {

        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _) {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_WhenNoParams_ReturnErrorValidationMessage() {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Data Intitialize nedde for execute
            string username = String.Empty;
            string password = String.Empty;
            string expected = "Errores de validacion";

            //Act: Execute the method to test
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert: Where result will checked if OK or NOK
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_WhenParamsOK_ReturnSuccessMessage() {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Data Intitialize nedde for execute
            string username = "asanchez";
            string password = "1234";
            string expected = "Login OK";

            //Act: Execute the method to test
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert: Where result will checked if OK or NOK
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_WhenParamsNOK_ReturnUserNotFoundMessage() {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Data Intitialize nedde for execute
            string username = "asanchez";
            string password = "4444";
            string expected = "Usuario no Existe";

            //Act: Execute the method to test
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert: Where result will checked if OK or NOK
            Assert.AreEqual(expected, actual);
        }
    }
}