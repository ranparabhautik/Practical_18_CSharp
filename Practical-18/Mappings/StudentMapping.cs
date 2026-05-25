using AutoMapper;
using Practical_18.Models.DTOs;
using Practical_18.Models.Entities;

namespace Practical_18.Mappings
{
    public class StudentMapping:Profile
    {
        public StudentMapping()
        {
            CreateMap<Student, StudentCreateDTO>().ReverseMap();
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();
        }
    }
}
