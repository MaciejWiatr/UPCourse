using AutoMapper;
using UpCourse.Dtos;
using UpCourse.Entities;

namespace UpCourse.MappingProfiles
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Course, CourseResponseDto>();
            CreateMap<CourseAuthor, AuthorDto>();
            CreateMap<CourseSource, CourseSourceDto>();
            CreateMap<CourseTag, TagDto>();
            CreateMap<CourseTopic, TopicDto>();
        }
    }
}