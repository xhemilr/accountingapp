using AutoMapper;
using AccountingApp.Application.Requests.Identity;
using AccountingApp.Application.Responses.Identity;

namespace AccountingApp.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}