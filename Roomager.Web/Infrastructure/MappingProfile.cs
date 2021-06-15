﻿using System;
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
        }
    }
}