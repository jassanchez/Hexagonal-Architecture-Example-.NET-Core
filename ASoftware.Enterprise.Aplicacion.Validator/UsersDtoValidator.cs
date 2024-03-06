using ASoftware.Enterprise.Aplicacion.DTO;
using FluentValidation;

namespace ASoftware.Enterprise.Aplicacion.Validator {
    public class UsersDtoValidator : AbstractValidator<UsersDTO> {
        public UsersDtoValidator() { 
            RuleFor(u => u.Username).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
