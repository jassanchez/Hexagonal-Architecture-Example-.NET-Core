using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Transversal.Common;

namespace ASoftware.Enterprise.Aplicacion.Interfaz {
    public interface IUsersApplication {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
