using AutoMapper;
using Migrate.DTO;
using Migrate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {

            CreateMap<Employ, EmployeDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();

        }
    }
}
