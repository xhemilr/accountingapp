using AutoMapper;
using AccountingApp.Application.Responses.Identity;
using AccountingApp.Infrastructure.Models.Identity;

namespace AccountingApp.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, AccountingAppUser>().ReverseMap();
        }
    }
}