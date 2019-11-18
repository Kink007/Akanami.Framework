using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akanami.AspNetCore.Dtos.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akanami.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutoMapperController : ControllerBase
    {
        private readonly IMapper mapper;

        public AutoMapperController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SimpleDto>> Get()
        {
            List<SimpleModel> list = new List<SimpleModel>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(new SimpleModel() { Id = i, Name = $"name{i}", BirthDay = DateTime.Now.AddDays(-1 * i) });
            }

            var result = mapper.Map<List<SimpleDto>>(list);

            return await Task.FromResult(result);
        }
    }
}