using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            
            CreateMap<EnergyPaymentsConfigDTO, EnergyPaymentsConfig>().ReverseMap();
            CreateMap<WaterPaymentsConfigDTO, WaterPaymentsConfig>().ReverseMap();
            CreateMap<GasPaymentsConfigDTO, GasPaymentsConfig>().ReverseMap();
            CreateMap<PaymentConfigDTO, PaymentsConfig>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.ConfigId))
                .ForMember(a => a.EnergyPaymentConfig, b => b.MapFrom(c => c.EnergyPaymentConfig))
                .ForMember(a => a.WaterPaymentsConfig, b => b.MapFrom(c => c.WaterPaymentConfig))
                .ForMember(a => a.GasPaymentsConfig, b => b.MapFrom(c => c.GasPaymentConfig));
        }
    }
}
