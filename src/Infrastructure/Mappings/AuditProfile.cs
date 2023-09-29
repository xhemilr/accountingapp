using AutoMapper;
using AccountingApp.Application.Responses.Audit;
using AccountingApp.Infrastructure.Models.Audit;

namespace AccountingApp.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}