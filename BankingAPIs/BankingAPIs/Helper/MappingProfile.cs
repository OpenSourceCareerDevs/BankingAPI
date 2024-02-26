using AutoMapper;
using BankingAPIs.DTOs;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAccount, AccountDto>();

            CreateMap<AccountDto, CustomerAccount>();

            CreateMap<SignUp, CustomerAccount>();

            CreateMap<Login, LoginDTO>();

            CreateMap<LoginDTO, Login>();


        }
    }
}
