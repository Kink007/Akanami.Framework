using Akanami.AspNetCore.Dtos.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akanami.AspNetCore.AutoMappers
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SimpleModel, SimpleDto>();
        }
    }
}
