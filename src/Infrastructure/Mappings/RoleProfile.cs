using AutoMapper;
using AccountingApp.Application.Responses.Identity;
using AccountingApp.Infrastructure.Models.Identity;

namespace AccountingApp.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, AccountingAppRole>().ReverseMap();
        }
    }
}