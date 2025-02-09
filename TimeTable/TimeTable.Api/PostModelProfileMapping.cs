using AutoMapper;
using TimeTable.Api.PostModels;
using TimeTable.Core.Dtos;

namespace TimeTable.Api
{
    public class PostModelProfileMapping :Profile
    {
        public PostModelProfileMapping()
        {
            CreateMap<AvailabilityPostModel, AvailabilityDto>();
            CreateMap<ClassPostModel, ClassDto>();
            CreateMap<SubjectPostModel, SubjectDto>();
            CreateMap<TeacherPostModel, TeacherDto>();

        }
    }
}
