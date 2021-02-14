using AutoMapper;
using Education_Api_L1.Dtos.SchoolDto;
using Education_Api_L1.Models;

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
