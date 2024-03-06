using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Aplicacion.Validator;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Transversal.Common;
using AutoMapper;

namespace ASoftware.Enterprise.Aplicacion.Main {
    public class UsersApplication : IUsersApplication {

        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersDtoValidator) {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator;
        }
    
        public Response<UsersDTO> Authenticate(string username, string password) {
            var response = new Response<UsersDTO>();
            var validation = _usersDtoValidator.Validate(new UsersDTO() { Username =  username, Password = password });

            if(!validation.IsValid) {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Login OK";
            } catch (InvalidOperationException){
                response.IsSuccess = true;
                response.Message = "Usuario no Existe";
            } catch(Exception e){
                response.Message = e.Message;
            }
            return response;
        }
    }
}
