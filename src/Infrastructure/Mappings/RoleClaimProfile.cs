using AccountingApp.Infrastructure.Models.Identity;
using AutoMapper;
using AccountingApp.Application.Requests.Identity;
using AccountingApp.Application.Responses.Identity;

namespace AccountingApp.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, AccountingAppRoleClaim>()
                .ForMember(nameof(AccountingAppRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(AccountingAppRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, AccountingAppRoleClaim>()
                .ForMember(nameof(AccountingAppRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(AccountingAppRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}