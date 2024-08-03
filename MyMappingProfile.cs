using AutoMapper;
using ECommerceWebAPI.DTO;

namespace ECommerceWebAPI
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<CustomerDTO, Customer>().ForMember(src => src.IsDeleted, act => act.Ignore());
        }
    }
}
