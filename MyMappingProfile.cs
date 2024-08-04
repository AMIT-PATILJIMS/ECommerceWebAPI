using AutoMapper;
using ECommerceWebAPI.DTO;

namespace ECommerceWebAPI
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            //CreateMap<Customer, CustomerDTO>().ForMember(src => src.IsDeleted, act => act.Ignore());
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
