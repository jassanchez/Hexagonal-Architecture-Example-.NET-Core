using ASoftware.Enterprise.Dominio.Entity;

namespace ASoftware.Enterprise.Infraestructura.Interfaz {
    public interface IUserRepository {
        Users Authenticate(string username, string password);
    }
}
