using AutoMapper;
using Education_Api_L1.Dtos.SchoolDto;
using Education_Api_L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education_Api_L1.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            //Source => Target
            CreateMap<School, SchoolReadDto>();
            CreateMap<SchoolCreateDto, School>();
            CreateMap<SchoolUpdateDto, School>();
            CreateMap<School, SchoolUpdateDto>();
        }
    }
}
