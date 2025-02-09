using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeTable.Core.Dtos;
using TimeTable.Core.Entity;

namespace TimeTable.Core
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping() 
        {
            CreateMap<AvailabilityEntity, AvailabilityDto>().ReverseMap();
            CreateMap<ClassEntity, ClassDto>().ReverseMap();
            CreateMap<SubjectEntity, SubjectDto>().ReverseMap();
            CreateMap<TeacherEntity, TeacherDto>().ReverseMap();

        }
    }
}
