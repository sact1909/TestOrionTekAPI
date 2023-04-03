using AutoMapper;
using System.Security;
using TestOrionTekAPI.Data.Entities;
using TestOrionTekAPI.Repo.DTOs;

namespace TestOrionTekAPI.Profiles
{
    public class AutoMapProfile : Profile
    {

        public AutoMapProfile()
        {
            CreateMap<Employees, EmployeesDTO>()
                .ForMember(des => des.Address, mf => mf.MapFrom(src => src.Address))
                .ReverseMap();
            CreateMap<EmployeesDTO, Employees>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }

    }
}
