using AutoMapper;
using Roomager.Data;
using Roomager.Web.Models.PaymentsModels;

namespace Roomager.Web.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentsRecordDTO, PaymentsRecord>().ReverseMap();
        }
    }
}
