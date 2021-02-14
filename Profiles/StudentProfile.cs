using AutoMapper;
using Education_Api_L1.Dtos.StudentDto;
using Education_Api_L1.Models;

namespace Education_Api_L1.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //Source => Target
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
    }
}
