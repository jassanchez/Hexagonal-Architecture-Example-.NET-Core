using ASoftware.Enterprise.Dominio.Entity;

namespace ASoftware.Enterprise.Dominio.Interfaz {
    public interface IUsersDomain {
        Users Authenticate(string username, string password);
    }
}
