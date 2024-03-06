using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Dominio.Entity;
using AutoMapper;

namespace ASoftware.Enterprise.Transversal.Mapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Customers,CustomersDTO>().ReverseMap();
            CreateMap<Users,UsersDTO>().ReverseMap();

            /**
             * En caso de que cada campo no coincida, hacerlo
             * de manera manual
             */
        /*
            CreateMap<Customers, CustomersDTO>().ReverseMap().ForMember(destino => destino.CustomerID, origen => origen.MapFrom(src => src.CustomerID));
        */
        }
    }
}