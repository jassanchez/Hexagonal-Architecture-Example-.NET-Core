using ASoftware.Enterprise.Dominio.Entity;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Infraestructura.Interfaz;

namespace ASoftware.Enterprise.Dominio.Core {
    public class UsersDomain : IUsersDomain {

        private readonly IUserRepository _userRepository;

        public UsersDomain(IUserRepository userRepository) {
            _userRepository = userRepository;  
        }

        public Users Authenticate(string username, string password) {
            return _userRepository.Authenticate(username, password);
        }
    }
}
